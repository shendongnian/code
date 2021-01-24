    public void OnDataChange(DataSnapshot snapshot)
        {
            var items = snapshot.Children?.ToEnumerable<DataSnapshot>();
            HashMap map;
            foreach (DataSnapshot item in items)
            {
                //filter the user first
                map = (HashMap)item.Value;
                string userId = map.Get("Ref")?.ToString();
                if (userId!=null&& userId == user.uid)
                {
                    //do what you want to do here.
                }
            }
 
