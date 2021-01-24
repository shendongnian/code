    public class Indexer : MarkupExtension, IValueConverter
    {
        public Indexer(object a0)
        {
            _arguments.Add(a0);
        }
        public Indexer(object a0, object a1)
        {
            _arguments.Add(a0);
            _arguments.Add(a1);
        }
        public Indexer(object a0, object a1, object a2)
        {
            _arguments.Add(a0);
            _arguments.Add(a1);
            _arguments.Add(a2);
        }
        public Indexer(object a0, object a1, object a2, object a3)
        {
            _arguments.Add(a0);
            _arguments.Add(a1);
            _arguments.Add(a2);
            _arguments.Add(a3);
        }
        private List<object> _arguments = new List<object>();
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        public object Convert(Object value, Type type, Object converterParameter, System.Globalization.CultureInfo cultureInfo)
        {
            var argTypes = _arguments.Select(p => p.GetType()).ToList();
            //  Indexers with the correct number of parameters
            var sameAryIndexers = value.GetType().GetProperties()
                .Where(prop => 
                    prop.Name == "Item"
                    //  Must have same number of parameters
                    && prop.GetIndexParameters().Length == argTypes.Count)
                .ToList();
            var indexerProperties =
                sameAryIndexers
                .Where(prop =>
                    prop.GetIndexParameters()
                        .Select(pi => pi.ParameterType)
                        .Zip(argTypes, (paramType, argType) => paramType.Equals(argType))
                        .All(b => b)
                ).ToList();
            //  If no exact match, try overloads. This is sketchy, if you ask me. 
            if (indexerProperties.Count != 1)
            {
                indexerProperties =
                    sameAryIndexers
                    .Where(prop =>
                        prop.GetIndexParameters()
                            .Select(pi => pi.ParameterType)
                            .Zip(argTypes, (paramType, argType) => paramType.IsAssignableFrom(argType))
                            .All(b => b)
                    ).ToList();
            }
            if (indexerProperties.Count != 1)
            {
                var argTypeNames = String.Join(", ", argTypes.Select(t => t.Name));
                throw new Exception($"Unable to resolve overload: Input arguments {argTypeNames}, {indexerProperties.Count} matching indexers.");
            }
            try
            {
                var x = indexerProperties.First().GetValue(value, _arguments.ToArray());
                return x;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public object ConvertBack(Object value, Type type, Object converterParameter, System.Globalization.CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
        protected bool IsTypesAssignableFrom(IEnumerable<Type> to, IEnumerable<Type> from)
        {
            return to.Zip(from, (tt, tf) => tt.IsAssignableFrom(tf)).All(b => b);
        }
    }
