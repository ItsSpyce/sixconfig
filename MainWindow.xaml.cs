using SixConfig.Core;
using SixConfig.Views;
using System.Windows;
using System.Windows.Controls;

namespace SixConfig
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public static MainWindow Instance { get; private set; }

    public int LoadingPercent { get; set; } = 0;
    public bool IsLoading { get; set; } = true;
    public Router Router { get; }
    

    public MainWindow()
    {
      Instance = this;
      InitializeComponent();
      Router = Router.CreateBuilder(this)
        .UseRoute<Home>("home")
        .UseRoute<Settings>("settings")
        .UseRoute<About>("about")
        .UseFrame(Root)
        .Build();

      Router.NavigateTo("/home?Test=42");


    }

    private void NavigateToHome(object sender, RoutedEventArgs e)
    {
      Router.NavigateTo("/home");
    }

    private void NavigateToSettings(object sender, RoutedEventArgs e)
    {
      Router.NavigateTo("/settings");
    }

    private void NavigateToAbout(object sender, RoutedEventArgs e)
    {
      Router.NavigateTo("/about");
    }
  }
}
