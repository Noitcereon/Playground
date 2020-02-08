using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Playground.Common
{
    public class RelayCommand : ICommand
    {
        private Action _action;

        /// <summary>
        /// An ultra simple RelayCommand with CanExecute always returning true.
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _action();
        }

        public event EventHandler CanExecuteChanged;
    }
}
