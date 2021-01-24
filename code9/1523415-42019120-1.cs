              List<CEntity> resultRange = new List<CEntity>();
        
                foreach (var list in pages.Batch(10))
                {
        
                    foreach (var item in list)
                    {
                        IWrapper Wrapper1 = InitializeWrapper(ent);
                        tasks.Add(Task.Run(() =>  FetchSomeDataFromSynchronusAPI(Wrapper1, item)));  
        
                    }
                }
        
           var results = await Task.WhenAll(tasks);
           resultRange.AddRange(results.SelectMany(x => x.ToList()).ToList());
