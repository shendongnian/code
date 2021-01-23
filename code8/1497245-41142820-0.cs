    [TestFixture]
    public class YourTest
    {
        [Test, TestCaseSource(typeof(YourTestCaseProvider), nameof(YourTestCaseProvider.TenantsRules)]
        public void CheckDNQTenantsRules(DNQTenantData testData)
        {
            CoreServicesBroker.DNQCoreServiceBroker broker = new CoreServicesBroker.DNQCoreServiceBroker();
            string actualDNQReason = string.Empty;
    
            int actualReturnCode = broker.CheckDNQTenants(testData.FormCode, testData.StateCode, testData.EffectiveDate, testData.NumberOfTenants, ref actualDNQReason);
    
            Assert.AreEqual(testData.ExpectedDNQReturnCode, actualReturnCode);
            Assert.AreEqual(testData.ExpectedDNQReason, actualDNQReason);
        }
    }
    public class YourTestCaseProvider
    {
        public static IEnumerable TenantsRules()
        {
            yield return new TestCaseData(new DNQTenantData() { FormCode = 9, StateCode = "OH", EffectiveDate = DateTime.Now, NumberOfTenants = 7, ExpectedDNQReturnCode = 1, ExpectedDNQReason = "Number of Tenants exceeded." })
            yield return new TestCaseData(new DNQTenantData() { FormCode = 9, StateCode = "OH", EffectiveDate = DateTime.Now, NumberOfTenants = 5, ExpectedDNQReturnCode = 0, ExpectedDNQReason = "" });
        }
    }
