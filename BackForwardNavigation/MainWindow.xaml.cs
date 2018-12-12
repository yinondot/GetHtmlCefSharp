using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp.Wpf;
using CefSharp.Internals;
using CefSharp;


namespace BackForwardNavigation
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void btnBack_Click(object sender, RoutedEventArgs e)
      {
         if (Browser.CanGoBack)
         {
            Browser.Back();
         }
      }

      private void Navigate_Click(object sender, RoutedEventArgs e)
      {
         if (!string.IsNullOrWhiteSpace(AddressBox.Text))
         {
            Browser.Address = AddressBox.Text;
         }
      }

      private void btnForward_Click(object sender, RoutedEventArgs e)
      {
         if (Browser.CanGoForward)
         {
            Browser.Forward();
         }
      }

      private void ChromiumWebBrowser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
      {
         Dispatcher.BeginInvoke((Action)(() =>
         {
            AddressBox.Text = e.Url;
            btnBack.IsEnabled = Browser.CanGoBack;
            btnNavigate.IsEnabled = !string.IsNullOrWhiteSpace(AddressBox.Text);
            btnForward.IsEnabled = Browser.CanGoForward;

         }));
      }
   }
}
