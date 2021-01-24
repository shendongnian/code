        Dictionary<string, string> AliasDict = new Dictionary<string, string>()
        {
           {  "Toys" , "Toy"},     // plural form
           {  "Game" , "Toy"},     // synonym 
           {  "Games" , "Toy"},    // plural synonym
           { "Sheeps" , "Sheep" }
        };
        public string ResolveAlias(string alias)
        {
            if (AliasDict.ContainsKey(alias))
            {
                return AliasDict[alias];
            }
            return alias;
        }
