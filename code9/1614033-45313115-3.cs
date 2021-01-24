    public interface IDataClassParser {
        DataClass Parse(string data);
    }
    public class DefaultDataClassParser : IDataClassParser {
        public DataClass Parse(string data) {
            return new DataClass {
                Property1 = data.Substring(0, 2),
                Property2 = data.Substring(3, 5),
                Property3 = data.Substring(9, 10)
            };
        }
    }
