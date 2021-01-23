    public Post GetPost(ObjectId id)
    {
        //If using FindOne() you won't need FirstOrDefault()
        return _db.GetCollection<Product>("Product").Find(x => x.Id == id).FirstOrDefault();
    }
