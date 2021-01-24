    public void runSP(int Id){
        using(var context = new Entities())
        {
            SqlParameter idParam = new SqlParameter("@id", Id);
            var x = context.Database.SqlQuery<entity>("exec sp_ChosenSP @id", idParam ).ToList<entity>();
            context.SaveChanges();
        }
    }
