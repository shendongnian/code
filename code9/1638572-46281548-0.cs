        public class A
    {
        public float x;
        public string name;
        public int weight;
    
    public A(float x, string name, int weight)
    {
        this.x = x;
        this.name = name;
        this.weight = weight;
    }
    
    List<A> allAs = new List<A>();
    
    allAs.Add(new A(10, "CAR", 3));
    allAs.Add(new A(22, "BUS", 4));
    allAs.Add(new A(100, "TRAIN", 2));
    allAs.Add(new A(0, "HYPERLOOP", 1));
