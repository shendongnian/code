    namespace ABC
    {
        class UnitTest
        {
            private object mySpecialObject;
            [TestInitialize]
            public void CreateObject()
            {
                mySpecialObject = CreateSpecialObject();
            }
    
            [TestMethod]
            public void Display()
            {
                //Here i want to use the created object instead of using object.
                DoStuff(mySpecialObject);
            }
        }
    }
