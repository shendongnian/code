    using (var spt = new StoredProcedureTranslator<DbContext>())
    {
         var foo = spt.Translate<FooEntity>("[dbo].[foo_get]", null)
             .Include<BarEntity>()
             .FirstOrDefault();
    }
