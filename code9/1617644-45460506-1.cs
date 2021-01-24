     var items = new[] 
                {
                     new TreeModel{ StreamName = "a" },
                     new TreeModel{ StreamName = "b" , Parent = "a" },
                     new TreeModel{ StreamName = "c" , Parent = "a" },
                     new TreeModel{ StreamName = "d" , Parent = "b" }
                };
    
                //A list of all object I use a copy to remove already added items
            var context = items.ToList();
            //Gets the root elements the ones that have no parents
            var root = items.Where(tm => String.IsNullOrEmpty(tm.Parent) || tm.Parent == "none").Select(tm => CreateJObject(tm, context));    
                var data = new JArray(root);
    
                Console.WriteLine(data.ToString());
