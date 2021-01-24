        Mapper.Initialize(cfg =>
        {
            cfg.CreateMap<Kempe, KempeList>();
            cfg.CreateMap<List<Kempe>, KempeCollector>().ConvertUsing((kempeList, kempeCollector) =>
            {
                kempeCollector = new KempeCollector
                {
                    Name = kempeList[0].Name,
                    Collection = new List<KempeList>()
                };
                foreach (var kempe in kempeList)
                {
                    kempeCollector.Collection.Add(Mapper.Map<KempeList>(kempe));
                }
                return kempeCollector;
            });
            
        });
