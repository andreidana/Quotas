
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuotaManager;

namespace QuotaManagerTest
{
    [TestClass]
    public class QuotaCreatorTest
    {
        private QuotaCreator quotaCreator;

        [TestInitialize]
        public void Initialize()
        {
            quotaCreator = new QuotaCreator();
        }

        [TestMethod]
        public void ShouldCreateNewQuota_WhenCalled()
        {
            Assert.IsInstanceOfType(quotaCreator.CreateQuota(), typeof(Quota));
        }
    }
}
