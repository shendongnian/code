        var n1 = new SqlParameter("@name1", System.Data.SqlDbType.VarChar);
        n1.Value = "name 1 ";
        var u1 = new SqlParameter("@uid1", System.Data.SqlDbType.UniqueIdentifier);
        u1.Value = Guid.Parse("guid here");
        var n2 = new SqlParameter("@name2", System.Data.SqlDbType.VarChar);
        n2.Value = "name2";
        var u2 = new SqlParameter("@uid2", System.Data.SqlDbType.UniqueIdentifier);
        u2.Value = Guid.Parse("guid here");
        var sqlParams = new[]
        {
            n1, n2, u1, u2
        };
        using (var db = new DbContext("default"))
        {
            db.Database.ExecuteSqlCommand(@"
                Update property set name = @name1 where uid = @uid1; 
                Update property set name = @name2 where uid = @uid2;", sqlParams);
        }
