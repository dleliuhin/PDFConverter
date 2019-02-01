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
using System.IO;

namespace PDFConverter
{
    /// <summary>
    /// Interaction logic for sideToggleButton.xaml
    /// </summary>
    public partial class sideToggleButton : UserControl
    {
        RotateTransform rotation = new RotateTransform(180);

        public sideToggleButton()
        {
            InitializeComponent();
        }

        private void sidebarButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
