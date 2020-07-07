

using WorkshopCalculator.Commands;

namespace WorkshopCalculator.ViewModel
{
    public interface ICalculatorViewModel
    {
        DelegateCommand AddCommand { get; }
        DelegateCommand SubstractCommand { get; }
        DelegateCommand MultiplyCommand { get; }
        DelegateCommand DivideCommand { get; }
        DelegateCommand CalculateCommand { get; }
        DelegateCommand WriteValueCommand { get; }

        void WriteToTextBox(double value);
    }
}
