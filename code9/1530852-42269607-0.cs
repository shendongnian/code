    public class DataObject {
      // locking object is a private implementation detail
      private object m_LockObject = new object();
      // TheMethod works with "this" DataObject instance, that's why
      // the method belongs to DataObject
      // let's return Task (e.g. to await it)
      public Task TheMethod() {
        // Task.Factory.StartNew is evil
        return Task.Run(() => {
          lock (m_LockObject) {
            // ...
          } 
        });
      }
      ...
    }
