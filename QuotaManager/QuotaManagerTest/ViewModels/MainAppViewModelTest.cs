using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotaManager.ViewModels;

namespace QuotaManagerTest.ViewModels
{
    [TestClass]
    public class MainAppViewModelTest
    {
        private MainAppViewModel _mainAppViewModel;

        [TestInitialize]
        public void Initialize()
        {
            _mainAppViewModel = new MainAppViewModel();
        }
    }
}
