using System;
using System.Windows.Input;

/// <summary>
/// Nechceme pouzivat click na UI, takto to dostaneme do view modelu
/// </summary>
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
            // v nasem pripade nepotrebujeme, jen demo.
            if (_canExecute == null) return true;
            return _canExecute.Invoke(parameter);
        }

        /// <summary>
        /// vykona akci
        /// nejdriv vola CanExecute
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _action.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }

}