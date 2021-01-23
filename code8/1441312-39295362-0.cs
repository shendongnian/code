     void CastingTest()
            {
                var dic1 = new Dictionary<string, string>();
                dic1.Add("Key", "Value");
                var dic2 = new ReadOnlyDictionary<string, string>(dic1);
                var castedDic = (IDictionary<string, string>)dic2;
                castedDic.Add("AnotherKey", "Another Value"); //System.NotSupportedException, Collection is read only
            }
