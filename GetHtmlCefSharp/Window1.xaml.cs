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
using System.Windows.Shapes;
using HtmlAgilityPack;

namespace GetHtmlCefSharp
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      public Window1()
      {
         InitializeComponent();

      }


      string filePath = @"C:\Users\yinon\OneDrive\Desktop\tableExample.html";
      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         try
         {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(filePath);
           // var tablesCollection = doc.DocumentNode.SelectNodes("//table");

            var bodyCollection = doc.DocumentNode.SelectNodes("//tbody");
            var rowCollection = bodyCollection[0].SelectNodes(".//tr");

            int count = 0;

            List<string> stringResults = new List<string>();
            for (int i = 0; i < 10; i++)
            {
               var strongCollection = rowCollection[i].SelectNodes(".//strong");
               try
               {
                  stringResults.Add(strongCollection[1].InnerHtml);
               }
               catch (Exception)
               {

                  count++;
               }
               
            }

            List<int> results = new List<int>();
            foreach (var item in stringResults)
            {
               string temp;
               temp = item.Trim();
            var twoResults=   temp.Split(':');
               twoResults[0] = twoResults[0].Trim();
               twoResults[1] = twoResults[1].Trim();
               results.Add(int.Parse(twoResults[0]) - int.Parse(twoResults[1]));
            }
            double sum = 0;
            foreach (var item in results)
            {
               sum += item;
               tbHtml.Text += item + Environment.NewLine;
            }
            tbHtml.Text += $"{count} draw results" +Environment.NewLine;
            tbHtml.Text += $"Result={sum / 10}";
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }

      }
   }
}
