    public class ModelMapper {
        private readonly List<SchemaAndHandler> _handlers = new List<SchemaAndHandler>();
        public void AddModelHandler<T>(Func<T, object> handler) {
            // generate schema once
            var schema = new JSchemaGenerator().Generate(typeof(T));
            _handlers.Add(new SchemaAndHandler(schema, typeof(T), o => handler((T) o)));
        }
        public object Parse(string json) {
            var raw = JObject.Parse(json);
            foreach (var handler in _handlers) {
                // validate according to each schema
                if (raw.IsValid(handler.Schema)) {
                    return handler.Handler(JsonConvert.DeserializeObject(json, handler.Type));
                }
            }
            // or throw
            return null;
        }
        private class SchemaAndHandler {
            public SchemaAndHandler(JSchema schema, Type type, Func<object, object> handler) {
                Schema = schema;
                Type = type;
                Handler = handler;
            }
            public JSchema Schema { get; }
            public Type Type { get; }
            public Func<object, object> Handler { get; }
        }
    }
    public class Model1 {
        public int Id { get; set; }
    }
    public class Model2 {
        public string Name { get; set; }
    }
