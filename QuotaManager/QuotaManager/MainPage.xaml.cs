using Windows.UI.Xaml.Controls;
using QuotaManager.ViewModels;

namespace QuotaManager
{
    public sealed partial class MainPage
    {
        private readonly MainAppViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new MainAppViewModel();
            DataContext = _viewModel;
        }

        private void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            _viewModel.ShowQuotasPerWeek.Execute(e.ClickedItem);
        }
    }
}
