using System;
using System.Windows.Input;

namespace WorkshopCalculator.Commands
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _action;
        private Predicate<object> _canExecute;
        public DelegateCommand(Action<object> action, Predicate<object> canExecute = null)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _action.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
