            public void TestCreateModel()
        {
            RootObject rootObject = new RootObject();
            rootObject.from_ProductName = "Prod1";
            rootObject.to_ProductName = "Prod2";
            rootObject.column_names = new List<string>()
                {"ProductName", "ProductID"};
            var dataList = new List<object>();
            dataList.Add("Alice Mutton,"+ 17);
            dataList.Add("Aniseed Syrup," + 2);
            dataList.Add("Boston Crab Meat," + 250.1);
            rootObject.data = new List<List<object>>() {dataList};
            string JSONString = JsonConvert.SerializeObject(rootObject);
        }
