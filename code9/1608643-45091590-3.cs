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
        var dicFields = new Dictionary<string, IField<object>>();
        dicFields.Add("param1", new Field<object>("Hello"));
        dicFields.Add("param2", new Field<object>(2));
        MyMethod<object>(dicFields);
    }
    public void MyMethod<T>(IDictionary<string, IField<T>> parameters)
    {
        var param2 = parameters["param2"].Value;
    }
