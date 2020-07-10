
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Ink;
using WorkshopCalculator.Commands;
using WorkshopCalculator.Model;

namespace WorkshopCalculator.ViewModel
{
    public class SimpleCalculatorViewModel : ICalculatorViewModel, INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private Calculator calculatorModel;
        private double firstValue;
        private double secondValue;
        private string textBoxValue = "0";
        private bool actionRepeated = false;
        private bool startNewNumber = false;

        private Func<double, double, double> lastAction;
        private bool _hasErrors;

        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand AddCommand { get; }
        public DelegateCommand SubstractCommand { get; }
        public DelegateCommand MultiplyCommand { get; }
        public DelegateCommand DivideCommand { get; }
        public DelegateCommand CalculateCommand { get; }
        public DelegateCommand WriteValueCommand { get; }

        public string TextBoxValue
        {
            get => textBoxValue;
            set
            {
                SetProperty(ref textBoxValue, value);
                ValidateTextBox();
            }
        }


        public SimpleCalculatorViewModel()
        {
            calculatorModel = new Calculator();

            AddCommand = new DelegateCommand(x => SetAndExecuteAction(calculatorModel.Add));
            SubstractCommand = new DelegateCommand(x => SetAndExecuteAction(calculatorModel.Substract));
            MultiplyCommand = new DelegateCommand(x => SetAndExecuteAction(calculatorModel.Multiply));
            DivideCommand = new DelegateCommand(x => SetAndExecuteAction(calculatorModel.Divide));
            CalculateCommand = new DelegateCommand(x =>
            {
                if (!actionRepeated)
                    secondValue = double.Parse(TextBoxValue);

                TextBoxValue = lastAction.Invoke(firstValue, secondValue).ToString();
                firstValue = double.Parse(TextBoxValue);
                actionRepeated = true;
                startNewNumber = true;
            });

            WriteValueCommand = new DelegateCommand(x => WriteToTextBox(double.Parse((string) x)));

            startNewNumber = true;
        }

        private void SetAndExecuteAction(Func<double, double, double> mathAction)
        {
            firstValue = double.Parse(TextBoxValue);

            lastAction = mathAction;

            actionRepeated = false;
            startNewNumber = true;
        }

        private void SetProperty<T>(ref T target, T value)
        {
            if (Equals(target, value)) return;

            target = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void WriteToTextBox(double value)
        {
            if (startNewNumber)
                TextBoxValue = value.ToString();
            else
                TextBoxValue += value;
            startNewNumber = false;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if(errors.ContainsKey(propertyName))
                return errors[propertyName];
            return null;
        }

        public bool HasErrors => errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void ValidateTextBox()
        {
            if (string.IsNullOrWhiteSpace(TextBoxValue))
            {

                errors[nameof(TextBoxValue)].Add("Value is empty");
                errors[nameof(TextBoxValue)].Add("Value should be number");
                ErrorsChanged.Invoke(this, new DataErrorsChangedEventArgs(nameof(TextBoxValue)));
            }
            else
            {
                errors[nameof(TextBoxValue)] = new List<string>();
            }
        }

        public Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>
        {
            {nameof(TextBoxValue), new List<string>()}
        };
    }
}
