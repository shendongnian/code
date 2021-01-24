    [TestClass]
    public class JsonSchemaValidatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(DataMisalignedException))]
        public void ShouldThrowOnBadPhoneNumber()
        {
            JsonSchemaValidator.validateAgainstJsonSchema(ProviderService.getErronousProviders(), "./provider-schema.json");
        }
    }
