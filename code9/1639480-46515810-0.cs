	var query = from a in collection.AsQueryable()
				join b in collectionTableB.AsQueryable()
					on a.AssemblyId equals b.AssemblyId into bj
				from b in bj.DefaultIfEmpty()
				join c in collectionTableC.AsQueryable() 
					on b.PcbaId equals c.PcbaId into cj
				from c in cj.DefaultIfEmpty()
				select new ConfigurableItemDto {
                     a.SomeAProperty,
                     b.SomeBProperty,
                     c.SomeCProperty,
				};
