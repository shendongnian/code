    public interface IMyReadOnlyInterface<TKey, TValue> : IReadOnlyDictionary<TKey, TValue> {
    IEqualityComparer<TKey> Comparer { get; }
    }
    public class MyReadOnlyDict<TKey, TValue> : Dictionary<TKey, TValue>, IMyReadOnlyInterface<TKey, TValue> {
    }
    
    public void TestMethod(IMyReadOnlyInterface<string, object> dict){
        var compareMe = dict.Comparer;
        //DO STUFF
    }
