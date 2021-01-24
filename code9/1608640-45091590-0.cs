    public interface IField
    {
    }
    public interface IField<T> : IField
    {
        T Value { get; }
    }
    public class Field<T> : IField<T>
    {
        public Field(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
    }
    public void Generic()
    {
        var dicFields = new Dictionary<string, IField<string>>();
        dicFields.Add("param1", new Field<string>("Hello"));
        dicFields.Add("param2", new Field<string>("Hello"));
        MyMethod<String>(dicFields);
    }
    public void MyMethod<T>(IDictionary<string, IField<T>> parameters)
    {
        var param2 = parameters["param2"].Value;
    }
