    using (RedisClient Client = new RedisClient(_ReplicaHost))
    {
        for (int i = 0; i < 100000; i++)
        {
            Client.AddItemToSet(key, value);
        } 
    }
