        public class ObjectInitGenerator
    {
        public static string ToObjectInitializer(Object obj)
        {
            var sb = new StringBuilder(1024);
            sb.Append("var x = ");
            sb = WalkObject(obj, sb);
            sb.Append(";");
            return sb.ToString();
        }
        private static StringBuilder WalkObject(Object obj, StringBuilder sb)
        {
            var properties = obj.GetType().GetProperties();
            var type = obj.GetType();
            var typeName = type.Name;
            sb.Append("new " + type.Name + " {");
            bool appendComma = false;
            DateTime workDt;
            foreach (var property in properties)
            {
                if (appendComma) sb.Append(", ");
                appendComma = true;
                var pt = property.PropertyType;
                var name = pt.Name;
                var isList = property.PropertyType.GetInterfaces().Contains(typeof(IList));
                var isClass = property.PropertyType.IsClass;
                if (isList)
                {
                    IList list = (IList)property.GetValue(obj, null);
                    var listTypeName = property.PropertyType.GetGenericArguments()[0].Name;
                    if (list != null && list.Count > 0)
                    {
                        sb.Append(property.Name + " = new List<" + listTypeName + ">{");
                        sb = WalkList(list, sb);
                        sb.Append("}");
                    }
                    else
                    {
                        sb.Append(property.Name + " = new List<" + listTypeName + ">()");
                    }
                }
                else if (property.PropertyType.IsEnum)
                {
                    sb.AppendFormat("{0} = {1}", property.Name, property.GetValue(obj));
                }
                else
                {
                    var value = property.GetValue(obj);
                    var isNullable = pt.IsGenericType && pt.GetGenericTypeDefinition() == typeof(Nullable<>);
                    if (isNullable)
                    {
                        name = pt.GetGenericArguments()[0].Name;
                        if (property.GetValue(obj) == null)
                        {
                            sb.AppendFormat("{0} = null", property.Name);
                            continue;
                        }
                    }
                    switch (name)
                    {
                        case "Int64":
                        case "Int32":
                        case "Int16":
                        case "Double":
                        case "Float":
                            sb.AppendFormat("{0} = {1}", property.Name, value);
                            break;
                        case "Boolean":
                            sb.AppendFormat("{0} = {1}", property.Name, Convert.ToBoolean(value) == true ? "true" : "false");
                            break;
                        case "DateTime":
                            workDt = Convert.ToDateTime(value);
                            sb.AppendFormat("{0} = new DateTime({1},{2},{3},{4},{5},{6})", property.Name, workDt.Year, workDt.Month, workDt.Day, workDt.Hour, workDt.Minute, workDt.Second);
                            break;
                        case "String":
                            sb.AppendFormat("{0} = \"{1}\"", property.Name, value);
                            break;
                        default:
                            // Handles all user classes, should likely have a better way
                            // to detect user class
                            sb.AppendFormat("{0} = ", property.Name);
                            WalkObject(property.GetValue(obj), sb);
                            break;
                    }
                }
            }
            sb.Append("}");
            return sb;
        }
        private static StringBuilder WalkList(IList list, StringBuilder sb)
        {
            bool appendComma = false;
            foreach (object obj in list)
            {
                if (appendComma) sb.Append(", ");
                appendComma = true;
                WalkObject(obj, sb);
            }
            return sb;
        }
    }
