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
using System.Windows.Threading;

namespace WpfDemoKeyControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Rectangle john;
        Point johnLocation;
        DispatcherTimer timer;
        bool up, down, left, right;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(30);
            timer.Tick += Timer_Tick;
            johnLocation = new Point(100, 100);
            john = new Rectangle();
            john.Width = 50;
            john.Height = 50;
            john.Fill = new SolidColorBrush(Colors.Blue);
            canvas.Children.Add(john);
            Canvas.SetLeft(john, johnLocation.X);
            Canvas.SetTop(john, johnLocation.Y);
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (up)
            {
                johnLocation.Y -= 1;
            }
            if (down)
            {
                johnLocation.Y += 1;
            }
            if (left)
            {
                johnLocation.X -= 1;
            }
            if (right)
            {
                johnLocation.X += 1;
            }
            Canvas.SetLeft(john, johnLocation.X);
            Canvas.SetTop(john, johnLocation.Y);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    left = true;
                    break;
                case Key.Right:
                    right = true;
                    break;
                case Key.Up:
                    up = true;
                    break;
                case Key.Down:
                    down = true;
                    break;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    left = false;
                    break;
                case Key.Right:
                    right = false;
                    break;
                case Key.Up:
                    up = false;
                    break;
                case Key.Down:
                    down = false;
                    break;
            }
        }
    }
}
