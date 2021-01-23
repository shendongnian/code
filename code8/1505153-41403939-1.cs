    dynamic json = JObject.Parse("{'glossary':{'title':'example glossary','GlossDiv':{'title':'S','GlossList':{'GlossEntry':{'ID':'C H A N G E   1','SortAs':'C H A N G E  2','GlossTerm':'Standard Generalized Markup Language','Acronym':'SGML','Abbrev':'ISO 8879:1986','GlossDef':{'para':'A meta-markup language, used to create markup languages such as DocBook.','GlossSeeAlso':['AAA','BBB','CCC']},'GlossSee':'markup'}}}}}");
    
    json.glossary.GlossDiv.GlossList.GlossEntry.ID = 1234;
    json.glossary.GlossDiv.GlossList.GlossEntry.SortAs = "abcde";
    
    string result = json.ToString();
