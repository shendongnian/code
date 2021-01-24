    void Main()
    {
    	var list = new List<IIndexedModelWithValue<Animal>>();	//NB, list uses the interface and not the class definition
    	list.Add(new IndexedModelWithValue<Dog>(new Dog(),0)); //creation could also be done with an extension to explicitely use the 'new Dog()' type
    	list.Add(new IndexedModelWithValue<Gecko>(new Gecko(),1));
    	
    	foreach(var t in list.OfType<IIndexedModelWithValue<Dog>>())
    		Console.WriteLine(t);
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
