    using System.Linq
    ...
    void Start()
    {
        System.Collections.ArrayList fruits = new System.Collections.ArrayList();
        fruits.Add("apple");
        fruits.Add("mango");
    
        IEnumerable<string> query =
            fruits.Cast<string>().Select(fruit => fruit);
    
        foreach (string fruit in query)
        {
            Debug.Log(fruit);
        }
    }
