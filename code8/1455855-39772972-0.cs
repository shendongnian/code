    public IEnumerable<T> LoadSomeLoads<T>(string table,int loadId)
    {
        using (ReconContext context = new ReconContext())
        {
           var sq;="SELECT * FROM "+ table+ "  WHERE LoadId = @p0";
           var results= context.SqlQuery<T>(sql,loadId)
                               .ToArray();
        }
    }
