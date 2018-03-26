using System.Windows.Input;
using QuotaManager.Common;

namespace QuotaManager.ViewModels
{
    public class MainAppViewModel: NotifyPropertyChanged
    {
        private ICommand _showQuotasCreationCommand;
        private IViewModelBase _currentView;

        public ICommand ShowQuotasCreationCommand
        {
            get
            {
                return _showQuotasCreationCommand ?? (_showQuotasCreationCommand = new CommandBase(i => ShowQuotasCreationViewModel(), null));
            }
        }

        public IViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                if (_currentView == value) return;
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        private void ShowQuotasCreationViewModel()
        {
            CurrentView = new QuotasCreationViewModel();
        }
    }
}
