using System;
using System.Windows.Input;

namespace QuotaManager.Common
{
    public class CommandBase : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        public event EventHandler CanExecuteChanged;

        public CommandBase(Action<object> executeDelegate, Predicate<object> canExecuteDelegate)
        {
            _execute = executeDelegate;
            _canExecute = canExecuteDelegate;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
