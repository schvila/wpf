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
        private void Button_1(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// pridano z xaml click= vygeneroval metodu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusButton_OnClick(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            ((ICalculatorViewModel)DataContext).Add();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //private void OnKeyDown(object sender, KeyEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}



    }
}
