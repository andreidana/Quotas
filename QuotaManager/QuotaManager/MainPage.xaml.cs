using QuotaManager.ViewModels;

namespace QuotaManager
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainAppViewModel();
        }
    }
}
