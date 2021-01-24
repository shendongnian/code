    public static class TypeHelper
    {
        public static Type GetTypeFromString(string typeString)
        {
            int pos = 0;
            return ParseInternal(typeString, ref pos);
        }
        private static Type ParseInternal(string name, ref int pos)
        {
            StringBuilder sb = new StringBuilder();
            List<Type> genericParameters = null;
            int arrayDimensions = 0;
            bool ignore = false;
            while (pos < name.Length)
            {
                char c = name[pos++];
                switch (c)
                {
                    case ',':
                        {
                            if (arrayDimensions > 0)
                                arrayDimensions++;
                            else
                                ignore = true;
                            break;
                        }
                    case '[':
                        {
                            if (name[pos] == '[')
                            {
                                if (genericParameters == null)
                                    genericParameters = new List<Type>();
                                pos++;
                                genericParameters.Add(ParseInternal(name, ref pos));
                            }
                            else if (genericParameters!=null)
                                genericParameters.Add(ParseInternal(name, ref pos));
                            else
                                arrayDimensions++;
                            break;
                        }
                    case ']':
                        {
                            var currentName = sb.ToString();
                            var type = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).FirstOrDefault(x => x.FullName == currentName);
                            if (name.Length > pos && name[pos] == ']')
                            {
                                pos++;
                            }
                            if (genericParameters != null)
                            {
                                return type.MakeGenericType(genericParameters.ToArray());
                            }
                            else if (arrayDimensions != 0)
                            {
                                return type.MakeArrayType(arrayDimensions);
                            }
                            return type;
                        }
                    default:
                        if (!ignore)
                            sb.Append(c);
                        continue;
                }
            }
            {
                var currentName = sb.ToString();
                var type = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).FirstOrDefault(x => x.FullName == currentName);
                if (genericParameters != null)
                {
                    return type.MakeGenericType(genericParameters.ToArray());
                }
                else if (arrayDimensions != 0)
                {
                    return type.MakeArrayType(arrayDimensions);
                }
                return type;
            }
        }
    }
