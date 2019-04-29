using Microsoft.VisualStudio.TestTools.UnitTesting;
using PDFConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PDFConverter.Tests
{
    [TestClass()]
    public class ModeToggleButtonTests
    {
        [TestMethod()]
        public void ModeToggleButtonInit_Test()
        {
            ModeToggleButton modeToggleButton = new ModeToggleButton();

            bool toggled = false;

            modeToggleButton.Toggled = toggled;

            toggled = modeToggleButton.Toggled;

            var grid = new Grid();

            int timestamp = new TimeSpan(DateTime.Now.Ticks).Milliseconds;
            const MouseButton mouseButton = MouseButton.Left;
            var mouseDownEvent =
               new MouseButtonEventArgs(Mouse.PrimaryDevice, timestamp, mouseButton)
               {
                   RoutedEvent = UIElement.MouseLeftButtonDownEvent,
                   Source = grid,
               };
               
        }
    }
}