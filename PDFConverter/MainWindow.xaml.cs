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
        }
    }
}
