using System.Windows;
using System.Windows.Controls;
using WorkshopCalculator.ViewModel;

namespace WorkshopCalculator.View
{
    /// <summary>
    /// Interaction logic for SimpleCalculator.xaml
    /// </summary>
    public partial class SimpleCalculator : UserControl
    {
        public SimpleCalculator(ICalculatorViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            //KeyDown += OnKeyDown;
        }
        public SimpleCalculator() : this(new SimpleCalculatorViewModel())
        {

        }
        private void ButtonBase1Click(object sender, RoutedEventArgs e)
        {
            ((ICalculatorViewModel)DataContext).WriteToTextBox((1));
            e.Handled = true;
        }
    }
}
