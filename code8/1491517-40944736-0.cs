    public class Datum<T>{
        public string name {get; set;}
        public T value;
    
        public Datum(string name, Func<T> getVal){
            this.name = name;
            this.value = getVal();
        }
        public T Value { get { return value; }}
    }
