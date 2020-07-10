using System;
using System.Collections.Generic;
using System.Text;
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

namespace WorkshopCalculator.View
{
    /// <summary>
    /// Interaction logic for AnimationTab.xaml
    /// </summary>
    public partial class AnimationTab : UserControl
    {
        public AnimationTab()
        {
        }

        private void ProgressBar_MouseEnter(object sender, MouseEventArgs e)
        {
            DoubleAnimation animace = new DoubleAnimation();
            animace.From = 0;
            animace.To = 100;
            animace.Duration = new Duration(TimeSpan.Parse("0:0:5"));
            //animace.BeginTime = TimeSpan.Parse("-0:0:2");
            animace.SpeedRatio = 1;
            animace.AutoReverse = true;
            animace.RepeatBehavior = new RepeatBehavior(TimeSpan.Parse("0:0:12.5"));
            ProgressBar.BeginAnimation(System.Windows.Controls.ProgressBar.ValueProperty, animace);
        }
    }
}
