    public abstract class SmartConcurrentDictionaryBase<TKey, TValue> : 
      System.Collections.Concurrent.ConcurrentDictionary<TKey, TValue>
    {
      public TValue GetOrAdd(TKey key) { return GetOrAdd(key, LoadNewValue); }
      protected abstract TValue LoadNewValue(TKey key);
    }
    public class LCProfilePictureDictionary : SmartConcurrentDictionaryBase<int, LCProfilePicture>
    {
      protected override LCProfilePicture(int accountID)
      { 
        return new LCProfilePicture(accountID);
      }
    }
    // use is
    // var pic = All.GetOrAdd(accountID);
