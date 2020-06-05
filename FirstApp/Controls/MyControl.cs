using System.Windows;
using System.Windows.Controls;

namespace FirstApp.Controls
{
    public class MyControl : Button
    {
        public string MyLabel
        {
            get { return (string)GetValue(_myDependencyProperty); }
            set { SetValue(_myDependencyProperty, value); }
        }

        public static readonly DependencyProperty _myDependencyProperty = DependencyProperty.Register(
            "MyLabel",
            typeof(string),
            typeof(MyControl),
            new PropertyMetadata("DefVal",
                new PropertyChangedCallback(propertyChangedCallback)));

        private static void propertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //MyControl mc = d as MyControl;
            //mc.MyLabel = "nepouzivat";
            //e.NewValue
            //e.OldValue
        }
    }
}