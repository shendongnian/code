     class entity
            {
                public string id { get; set; }
                public string catagory { get; set; }
                public IList<details> info { get; set; }
            }
            class details
            {
                public string id { get; set; }
                public string name { get; set; }
                public string locale { get; set; }
            }
     List<entity> list = new List<entity>();
                list.Add(new entity { id = "1", catagory = "cat1", info = new List<details> { new details { locale = "en", name = "d1" }, new details { locale = "fr", name = "d2" } } });
                list.Add(new entity { id = "2", catagory = "cat2", info = new List<details> { new details { locale = "en", name = "d3" } } });
    
                var result = list.Where(xx => xx.info.Any(yy => yy.locale == ""));
