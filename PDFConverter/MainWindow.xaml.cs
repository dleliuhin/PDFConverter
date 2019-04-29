/*!
 * @file MainWindow.xaml.cs
 * 
 * @author Dmitrii Leliuhin dleliuhin@mail.ru
 * 
 * @date 15.01.2019 14:35:39
 * 
 * @todo 
 * 1. Create Main Form.
 * 
 * @bug No known bugs.
 */

using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Media.Animation;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace PDFConverter
{
    /*! \class MainWindow
     *  \brief Main Form for choising files and folders.
     */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ConvertDemo();
            
        }

        public static void ConvertDemo()
        {
            var projectDirectory = Environment.CurrentDirectory;
            var exportFolder = System.IO.Directory.GetParent(projectDirectory).Parent.FullName;
            var exportFile = System.IO.Path.Combine(exportFolder, "Demo.pdf");

            using (var writer = new PdfWriter(exportFile))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var doc = new Document(pdf);
                    doc.Add(new iText.Layout.Element.Paragraph("Team Foxcatcher"));
                }
            }

            FoldersTreeView foldersTreeView = new FoldersTreeView();

            string curPath = foldersTreeView.getFullPath();
        }

        private void btnLeftMenuHide_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }

        private void btnLeftMenuShow_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowLeftMenu", btnLeftMenuHide, btnLeftMenuShow, pnlLeftMenu);
        }

        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, StackPanel pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
                pnlLeftMenu.SetValue(Grid.ColumnSpanProperty, 5);
                pnlLeftMenu.Margin = new Thickness(0, 0, 0, 0);
            }
            else if (Storyboard.Contains("Hide"))
            {
                btnHide.Visibility = System.Windows.Visibility.Hidden;
                btnShow.Visibility = System.Windows.Visibility.Visible;
                pnlLeftMenu.SetValue(Grid.ColumnSpanProperty, 1);
            }
        }
    }
}
