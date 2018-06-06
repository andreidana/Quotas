using System.Collections.Generic;
using System.Windows.Input;
using QuotaManager.Common;
using QuotaManager.Models;

namespace QuotaManager.ViewModels
{
    public class MainAppViewModel: NotifyPropertyChanged
    {
        private bool _quotaCreationFormVisibility;
        private List<Week> _weeksList;
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

        public List<Week> WeeksList
        {
            get => _weeksList;
            set
            {
                if (_weeksList == value) return;
                _weeksList = value;
                OnPropertyChanged(nameof(WeeksList));
            }
        }

        public MainAppViewModel()
        {
            _quotaCreationFormVisibility = false;
            var datesList = new DatesList.WeeksList();
            _weeksList = datesList.Weeks;
        }

        private void ShowQuotasCreationForm()
        {
            QuotaCreationFormVisibility = !_quotaCreationFormVisibility;
        }
    }
}
