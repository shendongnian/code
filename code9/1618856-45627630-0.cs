    public class GenericEventSink : MarshalByRefObject
    {
      public event GenericDelegate MessageReceived;
      public Type OriginalType { get; }
      public GenericEventSink(Delegate original)
      {
        OriginalType = original.GetType();
        MessageReceived += objects =>
        {
          try
          {
            return original.DynamicInvoke(objects);
          }
          catch (Exception ex)
          {
            return null;
          }
        };
      }
      public override object InitializeLifetimeService()
      {
        return null;
      }
      public object OnMessageReceived0()
      {
        return MessageReceived?.Invoke();
      }
      public object OnMessageReceived1(object o1)
      {
        return MessageReceived?.Invoke(o1);
      }
      public object OnMessageReceived2(object o1, object o2)
      {
        return MessageReceived?.Invoke(o1, o2);
      }
      public object OnMessageReceived3(object o1, object o2, object o3)
      {
        return MessageReceived?.Invoke(o1, o2, o3);
      }
    }
