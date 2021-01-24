    public class ModelMapper {
        private readonly List<Tuple<Type, JSchema>> _schemas = new List<Tuple<Type, JSchema>>();
        public ModelMapper(params Type[] models) {
            foreach (var model in models) {
                var schema = new JSchemaGenerator().Generate(model);
                _schemas.Add(Tuple.Create(model, schema));
            }
        }
        public object ParseModel(string json) {
            var raw = JObject.Parse(json);
            foreach (var schema in _schemas) {
                // validate according to each schema
                if (raw.IsValid(schema.Item2)) {
                    return JsonConvert.DeserializeObject(json, schema.Item1);
                }
            }
            // or throw
            return null;
        }
    }
