     [Test]
        [Description("(Source ID : Code-240) ABCD_019_Verify if user is able to edit information")]
        [Category("Regression")]
        [TestCaseSource(typeof(TestData), "NewDesignationRegistrationTestData")]
        public void VerifyUserIsAbleToEditInfo(IDictionary<string, string> parameters)
