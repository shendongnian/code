    Dictionary<string, Dictionary<string,string>> ImAssBackwards = new Dictionary<string, Dictionary<string, string>>();
    ImAssBackwards.Add("Dev", 
            new Dictionary<string, string>()
            {
                {
                    "Key1",
                    "Value1"
                },
                {
                    "Key2",
                    "Value2"
                }
            });
    Dictionary<string, string> PantOnHeadSilly = ImAssBackwards["Dev"];
