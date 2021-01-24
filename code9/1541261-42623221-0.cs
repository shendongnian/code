    using Business;
        var firstDict = new Dictionary<string,MyClassOne>
        {
            {"Key1", new MyClassOne() {PropertyOne = "FirstValue1"}}
        };
        var secondDict = new Dictionary<string, MyClassTwo>
        {
            {"Key2", new MyClassTwo() {PropertyOne = "SecondValue1"}}
        };
        foreach (var entryToCopy in firstDict)
        {
            secondDict.Add("NewStringKey", new MyClassTwo(){PropertyOne = entryToCopy.Value.PropertyOne});
        }
