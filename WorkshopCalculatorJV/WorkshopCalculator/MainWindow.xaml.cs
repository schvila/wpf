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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorkshopCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DoubleAnimation animace = new DoubleAnimation();
            //animace.From = 150;
            //animace.To = 600;
            //animace.Duration = new Duration(TimeSpan.Parse("0:0:10"));
            ////animace.BeginTime = TimeSpan.Parse("-0:0:2");
            ////animace.SpeedRatio = 1;
            ////animace.AutoReverse = true;
            ////animace.RepeatBehavior = new RepeatBehavior(TimeSpan.Parse("0:0:12.5"));
            //BeginAnimation(Window.HeightProperty, animace);

        }
    }
}
