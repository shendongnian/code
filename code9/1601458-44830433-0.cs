    using (var context = new SomeDataEntities())
    {
         var query = context.Set<SomeTable>();
         if (field1.HasValue)
         {
              query = query.Where(e => e.Field1 == field1.Value);
         }
         
         if (field2.HasValue)
         {
              query = query.Where(e => e.Field2 == field2.Value);
         }    
         var abc = query.Select(b => b.AnotherField);
    }
