/*!
 * @file ModeToggleButton.xaml.cs
 * 
 * @author Dmitrii Leliuhin dleliuhin@mail.ru
 * 
 * @date 20.01.2019 5:13:42
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

namespace PDFConverter
{
    /*! \class ModeToggleButton
     *  \brief Interaction logic for ModeToggleButton.xaml.
     */
    public partial class ModeToggleButton : UserControl
    {
        Thickness LeftSide = new Thickness(-60, 0, 0, 0);
        Thickness RigftSide = new Thickness(0, 0, -60, 0);
        SolidColorBrush Single = new SolidColorBrush(Color.FromRgb(160, 160, 160));
        SolidColorBrush Multiple = new SolidColorBrush(Color.FromRgb(130, 190, 125));

        HorizontalAlignment TextLeftSide = HorizontalAlignment.Left;
        HorizontalAlignment TextRightSide = HorizontalAlignment.Right;
        private String defaultText = "Single";
        private String rightText = "Multi";

        int fontSize = 18;

        private bool toggled = false;

        public ModeToggleButton()
        {
            InitializeComponent();
            Back.Fill = Single;
            toggled = false;
            Dot.Margin = LeftSide;
            textMode.HorizontalAlignment = TextRightSide;
            textMode.Text = defaultText;
            textMode.Margin = new Thickness(0, 0, 12, 0);
            textMode.FontSize = fontSize;
        }

        public bool Toggled
        {
            get => toggled;
            set => toggled = value;
        }

        private void Dot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!toggled)
            {
                Back.Fill = Multiple;
                toggled = true;
                Dot.Margin = RigftSide;
                textMode.HorizontalAlignment = TextLeftSide;
                textMode.Text = rightText;
                textMode.Margin = new Thickness(12, 0, 0, 0);
                textMode.FontSize = fontSize;
            }
            else
            {
                Back.Fill = Single;
                toggled = false;
                Dot.Margin = LeftSide;
                textMode.HorizontalAlignment = TextRightSide;
                textMode.Text = defaultText;
                textMode.Margin = new Thickness(0, 0, 12, 0);
                textMode.FontSize = fontSize;
            }
        }
    }
}
