    UnitySynchronizationContext.Install();
    class UnitySynchronizationContext : SynchronizationContext {
      static UnitySynchronizationContext _instance = null;
      GameObject gameObject;
      Queue<Tuple<SendOrPostCallback, object>> queue;
      private UnitySynchronizationContext() {
        gameObject = new GameObject("SynchronizationContext");
        gameObject.AddComponent<SynchronizationContextBehavoir>();
        queue =
          gameObject.GetComponent<SynchronizationContextBehavoir>()
            .Queue;
      }
      public static void Install() {
        if (SynchronizationContext.Current == null)
        {
          if (_instance == null)
          {
            _instance = new UnitySynchronizationContext();
          }
          SynchronizationContext.SetSynchronizationContext(_instance);
        }
      }
      public override void Post(SendOrPostCallback d, object state) {
        lock (queue)
        {
          queue.Enqueue(new Tuple<SendOrPostCallback, object>(d, state));
        }
      }
      class SynchronizationContextBehavoir : MonoBehaviour {
        Queue<Tuple<SendOrPostCallback, object>> callbackQueue
            = new Queue<Tuple<SendOrPostCallback, object>>();
      
        public Queue<Tuple<SendOrPostCallback, object>>
            Queue { get { return callbackQueue; }}
        IEnumerator Start() {
          while (true)
          {
            Tuple<SendOrPostCallback, object> entry = null;
            lock (callbackQueue)
            {
              if (callbackQueue.Count > 0)
              {
                entry = callbackQueue.Dequeue();
              }
            }
            if (entry != null && entry.Item1 != null)
            {
              try {
                entry.Item1(entry.Item2);
              } catch (Exception e) { 
                UnityEngine.Debug.Log(e.ToString());
              }
            }
            yield return null;
          }
        }
      }
    }
