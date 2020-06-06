using System;
using System.Windows.Input;


namespace WorkshopCalculator.Commands
{
    public class DelegateCommand : ICommand
    {
        private Action _action;
        private Predicate<object> _canExecute;

        public DelegateCommand(Action action, Predicate<object> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {

            if (parameter == null)
                return false;
            return true;
        }

        public void Execute(object parameter)
        {
            _action.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }

}