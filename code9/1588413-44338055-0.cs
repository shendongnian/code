    //Need to add all variables in the class
          public class obj 
            {
            public DateTime updated {get;set;}
            public string id {get;set;}
            public string Name {get;set;}
            
            public int highscore {get;set;}
            
            }
            
            var dic = new Dictionary<TKey, obj>();
            var sorted = dic.OrderBy(x=>x.Value.highscore).ToList();
