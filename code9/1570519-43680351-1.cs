    void Main()
    {
    	var list = LoadData().Select((a,i)=> (IIndexedModelWithValue<Animal>) Activator.CreateInstance(typeof(IndexedModelWithValue<>).MakeGenericType(a.GetType()), a,i)).ToList();
    	
    	foreach(var t in list.OfType<IIndexedModelWithValue<Dog>>())
    		Console.WriteLine(t);
    }
    
    static IEnumerable<Animal> LoadData()
    {
    	yield return new Dog();
    	yield return new Gecko();
    }
    
    public class IndexedModelWithValue<T>:IIndexedModelWithValue<T>
    {
        public IndexedModelWithValue(T value, int index)
        {
            Index = index;
            InnerValue = value;
        } 
    
        public int Index{get;set;}
    
        public T InnerValue { get; }
    }
    
    public interface IIndexedModelWithValue<out T>
    {
    	int Index{get;}
    	T InnerValue {get;}
    }
    
    class Animal { }
    class Dog : Animal { }
    class Gecko:Animal{}
