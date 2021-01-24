    public class BracketedQueryStringModelBinder<T> : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.CanWrite);
            Dictionary<string, object> values = new Dictionary<string, object>();
            foreach (var p in properties)
            {
                if (!IsNullable(p.PropertyType))
                {
                    object val = TryGetValueType(p.PropertyType, bindingContext, p.Name);
                    if (val != null)
                    {
                        values.Add(p.Name, val);
                    }
                }
                else
                {
                    object val = GetRefernceType(p.PropertyType, bindingContext, p.Name);
                    values.Add(p.Name, val);
                }
            }
            if (values.Any())
            {
                object boundModel = Activator.CreateInstance<T>();
                foreach (var p in properties.Where(i => values.ContainsKey(i.Name)))
                {
                    p.SetValue(boundModel, values[p.Name]);
                }
                return boundModel;
            }
            return null;
        }
        private static bool IsNullable(Type t)
        {
            if (t == null)
                throw new ArgumentNullException("t");
            if (!t.IsValueType)
                return true;
            return Nullable.GetUnderlyingType(t) != null;
        }
        private static object TryGetValueType(Type type, ModelBindingContext ctx, string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");
            ValueProviderResult result = ctx.ValueProvider.GetValue(string.Concat(ctx.ModelName, "[", key, "]"));
            if (result == null && ctx.FallbackToEmptyPrefix)
                result = ctx.ValueProvider.GetValue(key);
            if (result == null)
                return null;
            try
            {
                object returnVal = result.ConvertTo(type);
                ctx.ModelState.SetModelValue(key, result);
                return returnVal;
            }
            catch (Exception ex)
            {
                ctx.ModelState.AddModelError(ctx.ModelName, ex);
                return null;
            }
        }
        private static object GetRefernceType(Type type, ModelBindingContext ctx, string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");
            char firstChar = key[0];
            if (char.IsUpper(firstChar))
                key = char.ToLower(firstChar) + key.Substring(1);
            ValueProviderResult result = ctx.ValueProvider.GetValue(string.Concat(ctx.ModelName, "[", key, "]"));
            if (result == null && ctx.FallbackToEmptyPrefix)
                result = ctx.ValueProvider.GetValue(key);
            if (result == null)
                return null;
            try
            {
                object returnVal = result.ConvertTo(type);
                ctx.ModelState.SetModelValue(key, result);
                return returnVal;
            }
            catch (Exception ex)
            {
                ctx.ModelState.AddModelError(ctx.ModelName, ex);
                return null;
            }
        }
    }
