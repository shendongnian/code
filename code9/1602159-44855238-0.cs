    public  void OnDataChange(DataSnapshot snapshot)
                {
                    allMessages.clear();
    
                    var items = snapshot.Child("key")?.Child("users id")?.Children?.ToEnumerable<DataSnapshot>();
    
                    HashMap map;
                    foreach(DataSnapshot  item in items){
    
                    map = (HashMap)item.Value;
                        allMessages.Add(new EventMessageContent(map.Get("username")?.ToString(), map.Get("content")?.ToString()));
                    }
    
                    CommentViewAdapter adapter = new CommentViewAdapter(this, allMessages);
                    allMessages.Adapter = adapter;
    
                  }
