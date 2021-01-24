    public static void foo()
    {
        using (var con = ConnectionRepository.Get("MyConnection"))
        using (var cmd = new SqlCommand("SELECT * FROM MyTable", con))
        {
            var dr = cmd.ExecuteReader();
            //...
        }
    }
