    [Test]
    public async Task Test_Exception_RefreshAsync(){
            try
            {
                await vm.RefreshAsync();
                Assert.Fail("No exception was thrown");
            }
            catch (NotImplementedException e)
            {
                // Pass
            }
    }
