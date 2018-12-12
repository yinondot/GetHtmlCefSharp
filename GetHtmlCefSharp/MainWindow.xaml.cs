using System;
using System.Collections.Generic;
using System.IO;
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
using CefSharp;
using HtmlAgilityPack;

namespace GetHtmlCefSharp
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      const string filePath = @"C:\Users\yinon\OneDrive\Desktop\data1.txt";
      public MainWindow()
      {
         InitializeComponent();
      }

      private async void  Button_Click(object sender, RoutedEventArgs e)
      {
         
       //  Browser.Address = tbUrl.Text;
         File.WriteAllText(filePath, await Browser.GetSourceAsync());
         MessageBox.Show("DATA in file");
         HtmlDocument doc = new HtmlDocument();
         TextReader reader = File.OpenText(filePath);
         doc.Load(reader);
         reader.Close();

         List<string> hrefTags = new List<string>();

         foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//table"))
         {
           
         }


      }

      private void ChromiumWebBrowser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
      {

      }

      private void Button_Click_1(object sender, RoutedEventArgs e)
      {
         Browser.LoadHtml(tbUrl.Text);
         Browser.Address = tbUrl.Text;
      }
   }
}
