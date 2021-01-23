        bool FindAndUpdate2(BsonDocument target, int x)
        {
            BsonValue id, children;
            while (true)
            {
                try
                {
                    if (target.TryGetValue("_id", out children))
                    {
                        id = target.GetValue(1);
                        children = target.GetValue(3);
                    }
                    else
                    {
                        id = target.GetValue(0);
                        children = target.GetValue(2);
                    }
                    if (id.ToInt32() == x)
                    {
                        Update(target);  //change as you like
                        return true;   //success
                    }
                    else
                        target = children[0] as BsonDocument;
                }
                catch (Exception ex)
                {
                    return false;   //failed
                }
            }
        }
