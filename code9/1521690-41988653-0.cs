    public List<MyObjs> GetObjs(){
        using(var db = new MyDbContext()){
            var query = from x in db.mytable
                        select x;
            return query.ToList();
        }
    }
