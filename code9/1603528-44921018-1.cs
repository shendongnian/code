    public void tests: Testbase
    {
        [Test]
        public void testmethods()
        {
            string blabla = driverChrome.FindElement(By.id("dsd")).Text;
            Reuse.driverChrome = driverChrome;
            Reuse.FetchName(out string firstname, out string lastname);
            Assert.isTrue(firstname.equals(lastname));
        } 
}
