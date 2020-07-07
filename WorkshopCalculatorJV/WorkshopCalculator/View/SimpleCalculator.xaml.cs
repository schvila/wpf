using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        }

        public SimpleCalculator() : this(new SimpleCalculatorViewModel())
        {
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            object cont = ((Button) sender).Content;
            ((ICalculatorViewModel)DataContext).WriteToTextBox(double.Parse(cont.ToString()));

            e.Handled = true;
        }

        private void UIElement_OnKeyDown1(object sender, KeyEventArgs e)
        {

        }
    }
}
