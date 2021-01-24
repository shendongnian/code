        public void TestTypeCreator()
        {
            //create and save new type
            object _newProduct = DynamicTypeCreator
                .Create("NewProduct", @"C:\PROD")
                .AddPassThroughCtors(typeof(Product))
                .AddProperty("ProductName", typeof(string))
                .FinishBuildingAndSaveType("NewProduct.dll")
                .GetConstructor(new Type[0] { })
                .Invoke(new object[0] { });
            //set ProductName value
            _newProduct.GetType().GetProperty("ProductName").SetValue(_newProduct, "Cool Item");
            //get ProductName value
            string _prodName = _newProduct.GetType().GetProperty("ProductName").GetValue(_newProduct).ToString();
            //get StoreName value
            string _storeName = _newProduct.GetType().GetProperty("StoreName").GetValue(_newProduct).ToString();
        }
