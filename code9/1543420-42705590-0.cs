    interface IListener {
      void send(ISender sender, IMessage message);
    }
    interface ISender { }
    interface IMessage { }
    interface IPending {
      ISender from;
      IMessage message;
    }
    class Dispatcher {
      private Queue<IPending> messages = new Queue<IPending>();
      private Dictionary<ISender, List<IListener>> connections = new Dictionary<ISender, List<IListener>>();
      public void connect(ISender sender, IListener listener) {
        if (connections[sender] == null) {
          connections[sender] = new List<IListener>();
        }
        connections[sender].add(listener);
      }
      public void remove(ISender sender, IListener listener) { ... } // removes connection from connections
      public void send(ISender from, IMessage message) {
        messages.push({ from, message });
      }
      public void next() { // called in a loop, perhaps in a background thread
        if (messages.peek()) {
          var message = messages.pop();
          foreach(var listener in connections[message.from]) {
            listener.send(sender, message);
          }
        }
      }
    }
