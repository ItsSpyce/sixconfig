using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SixConfig.Views
{
  /// <summary>
  /// Interaction logic for Home.xaml
  /// </summary>
  public partial class Home : Page
  {
    public int Test { get; set; }

    public Home()
    {
      InitializeComponent();
    }
  }
}
