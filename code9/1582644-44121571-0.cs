      private Object lck;
      internal ConnectionManager()
        {
            lck = new Object();
            this.Connections = new List();
        }
      internal void AddConnection(Connection Connection)
        {
         lock (lck)
          {
            Connections.Add(Connection);
            OnAddConnection(Connection);
          }
        }
