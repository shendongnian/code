    public void OnDataChange(DataSnapshot snapshot)
            {
                var items = snapshot.Children?.ToEnumerable<DataSnapshot>();
    
                HashMap map;
                foreach (DataSnapshot item in items)
                {
    
                    map = (HashMap)item.Value;
    
                    Hero.Add(new Hero(item.Key.ToString(),map.Get("Name")?.ToString(), map.Get("Achievement")?.ToString(),map.Get("History")?.ToString(),map.Get("Quote")?.ToString()));
                    Console.WriteLine("Sending item key" +item.Key.ToString());
                    key = item.Key;
                }
    
                HeroAdapter adapter = new PeaceHeroAdapter(Hero,this);
    
    
            }
