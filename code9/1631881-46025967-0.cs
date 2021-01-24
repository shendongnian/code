     var enumList = new List<MyEnum>();
                var testNumbers = new List<int>{ 1, 2, 4};
                MyEnum enumerationSet = MyEnum.Type1 | MyEnum.Type2;
                foreach (var num in testNumbers)
                {
                    var doesExist = (((enumerationSet) & ((MyEnum) num)) != 0);
                    if (doesExist)
                        enumList.Add((MyEnum)num);
                }
    
                enumList.ForEach(x => Console.WriteLine(x.ToString()));
                return enumList;
