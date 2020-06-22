using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Controls;

namespace SixConfig.Core
{
  public sealed class Router
  {
    private Dictionary<string, Type> m_Routes;
    private Frame m_RootControl;

    public void NavigateTo(string route)
    {
      Uri uri;
      if (Uri.IsWellFormedUriString(route, UriKind.Relative))
      {

        uri = new Uri($"wpf:/{route}");
      }
      else if (Uri.IsWellFormedUriString(route, UriKind.Absolute))
      {
        uri = new Uri(route);
      }
      else
      {
        throw new UriFormatException();
      }
      var query = HttpUtility.ParseQueryString(uri.Query);
      if (m_Routes.TryGetValue(uri.Host, out var type))
      {
        var view = (Page)type.GetConstructor(new Type[0]).Invoke(null);
        foreach (var key in query.AllKeys)
        {
          object value = query[key];
          if (int.TryParse(value as string, out var num))
          {
            value = num;
          }
          else if (bool.TryParse(value as string, out var boolean))
          {
            value = boolean;
          }
          type.GetProperty(key).SetValue(view, value);
        }
        m_RootControl.Content = view;
      }
    }

    public static RouterBuilder CreateBuilder(Window window)
    {
      return new RouterBuilder(window);
    }

    public class RouterBuilder
    {
      private Window m_Window;
      private Frame m_Frame;
      private Dictionary<string, Type> m_Routes = new Dictionary<string, Type>();

      public RouterBuilder(Window window)
      {
        m_Window = window;
      }

      public RouterBuilder UseRoute<T>(string route) where T : Page
      {
        m_Routes.Add(route, typeof(T));
        return this;
      }

      public RouterBuilder UseFrame(Frame frame)
      {
        m_Frame = frame;
        return this;
      }

      public Router Build()
      {
        if (m_Frame == null && m_Window.Content is Grid grid)
        {
          m_Frame = new Frame { Name = "RouterFrame" };
          grid.Children.Add(m_Frame);
        }
        return new Router { m_Routes = m_Routes, m_RootControl = m_Frame };
      }
    }
  }
}
