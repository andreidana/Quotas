using System.Windows.Input;
using QuotaManager.Common;

namespace QuotaManager.ViewModels
{
    public class MainAppViewModel: NotifyPropertyChanged
    {
        private bool _quotaCreationFormVisibility;
        private ICommand _showQuotasCreationFormCommand;

        public ICommand ShowQuotasCreationCommand
        {
            get
            {
                return _showQuotasCreationFormCommand ?? (_showQuotasCreationFormCommand = new CommandBase(i => ShowQuotasCreationForm(), null));
            }
        }

        public bool QuotaCreationFormVisibility
        {
            get => _quotaCreationFormVisibility;
            set
            {
                if (_quotaCreationFormVisibility == value) return;
                _quotaCreationFormVisibility = value;
                OnPropertyChanged(nameof(QuotaCreationFormVisibility));
            }
        }

        public MainAppViewModel()
        {
            _quotaCreationFormVisibility = false;
            var datesList = new DatesList.DatesList();
        }

        private void ShowQuotasCreationForm()
        {
            QuotaCreationFormVisibility = !_quotaCreationFormVisibility;
        }
    }
}
