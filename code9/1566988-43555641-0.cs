    [TestFixture]
    public class YourFormTests
    {
        private Form frm;
    
        [OneTimeSetUp]
        public void SetUp()
        {
            frm = new Form();
            frm.Show();
        }
    
        [OneTimeSetup]
        public void TearDown()
        {
            frm?.Close();
            frm?.Dispose();
        }
    
        [Test]
        public void TestComboDisabled()
        {
            frm.cmbSomeName.Enabled = true;
            frm.comboDisable();
            Assert.IsFalse(frm.cmbSomeName.Enabled, "Combo is not disabled");
        } 
    }
