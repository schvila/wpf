using System.ComponentModel;
using WorkshopCalculator.Model;

namespace WorkshopCalculator.ViewModel
{
    public class SimpleCalculatorViewModel : ICalculatorViewModel, INotifyPropertyChanged
    {
        private readonly Calculator calculatorModel;
        private double firstValue;
        //private double secVal;
        private double textBoxValue;
        //private bool actionRepeated = false;
        //public DelegateCommand AddCommand { get; }
        public SimpleCalculatorViewModel()
        {
            calculatorModel = new Calculator();
            //AddCommand = new DelegateCommand(() => SetAndExecuteAction(calculatorModel.Add));
        }


        public double TextBoxValue
        {
            get => textBoxValue;
            set => SetProperty(ref textBoxValue, value);
        }


        //private void SetAndExecuteAction(Func<double, double, double> mathAction)
        //{
        //    //if (last)
        //    actionRepeated = false;
        //}
        public double Add()
        {
            var res = calculatorModel.Add(1, 1); //test volani
            TextBoxValue = res;
            return res;
        }

        private void SetProperty<T>(ref T target, T value)
        {
            if (Equals(target, value)) return;

            target = value;



            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
