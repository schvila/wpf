using System;
using System.ComponentModel;
using WorkshopCalculator.Commands;
using WorkshopCalculator.Model;

namespace WorkshopCalculator.ViewModel
{
    public class SimpleCalculatorViewModel : ICalculatorViewModel, INotifyPropertyChanged
    {
        private readonly Calculator calculatorModel;
        private double firstValue;
        private double secondValue;
        private string textBoxValue = "0";
        private bool actionRepeated = false;
        private bool startNewNumber = false;
        public DelegateCommand AddCommand { get; }
        public DelegateCommand SubstractCommand { get; }
        public DelegateCommand MultiplyCommand { get; }
        public DelegateCommand DivideCommand { get; }
        public DelegateCommand CalculateCommand { get; }
        public DelegateCommand WriteValueCommand { get; }

        private Func<double, double, double> lastAction;

        public SimpleCalculatorViewModel()
        {
            calculatorModel = new Calculator();
            AddCommand = new DelegateCommand((x) => SetAndExecuteAction(calculatorModel.Add));
            SubstractCommand = new DelegateCommand((x) => SetAndExecuteAction(calculatorModel.Substract));
            MultiplyCommand = new DelegateCommand((x) => SetAndExecuteAction(calculatorModel.Multiply));
            DivideCommand = new DelegateCommand((x) => SetAndExecuteAction(calculatorModel.Divide));
            CalculateCommand = new DelegateCommand((x) =>
            {
                if (!actionRepeated)
                    secondValue = double.Parse(TextBoxValue);

                TextBoxValue = lastAction.Invoke(firstValue, secondValue).ToString();

                firstValue = double.Parse(TextBoxValue);
                actionRepeated = true;
                startNewNumber = true;
            });
            WriteValueCommand = new DelegateCommand((x) =>
            {
                WriteToTextBox(double.Parse((string)x));
            });
            startNewNumber = true;
        }
        private void SetAndExecuteAction(Func<double, double, double> mathAction)
        {
            firstValue = double.Parse(TextBoxValue);

            lastAction = mathAction;
            actionRepeated = false;
            startNewNumber = true;
        }

        public void WriteToTextBox(double value)
        {
            if (startNewNumber)
                TextBoxValue = value.ToString();
            else
                TextBoxValue += value;
            startNewNumber = false;
        }

        public string TextBoxValue
        {
            get => textBoxValue;
            set => SetProperty(ref textBoxValue, value);
        }


        //public double Add()
        //{
        //    var res = calculatorModel.Add(1, 1); //test volani
        //    TextBoxValue = res;
        //    return res;
        //}

        private void SetProperty<T>(ref T target, T value)
        {
            if (Equals(target, value)) return;

            target = value;



            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
