using System.Windows.Controls;

namespace FirstApp.Folder
{
    /// <summary>
    /// Interaction logic for FirstControl.xaml
    /// </summary>
    public partial class FirstControl : UserControl
    {
        public FirstControl()
        {
            InitializeComponent();
        }
        //public string MyLabel
        //{
        //    get { return (string)GetValue(_myDependencyProperty); }
        //    set { SetValue(_myDependencyProperty, value); }
        //}

        //DependencyProperty _myDependencyProperty = DependencyProperty.Register(
        //    "MyLabel",
        //    typeof(string),
        //    typeof(FirstControl),
        //    new PropertyMetadata("DefVal"/*,
        //        new PropertyChangedCallback(propertyChangedCallback)*/));

    }
}
