        /// <summary>
        /// Gets the fully quantified name in C# format.
        /// </summary>
        public string CSharpFullName
        {
            get
            {
                if (m_CSharpFullName == null)
                {
                    var result = new StringBuilder(m_TypeInfo.ToString().Length);
                    BuildCSharpFullName(m_TypeInfo.AsType(), null, result);
                    m_CSharpFullName = result.ToString();
                }
                return m_CSharpFullName;
            }
        }
        static void BuildCSharpFullName(Type typeInfo, List<Type> typeArgs, StringBuilder result)
        {
            var localTypeParamCount = typeInfo.GetTypeInfo().GenericTypeParameters.Length;
            var localTypeArgCount = typeInfo.GetTypeInfo().GenericTypeArguments.Length;
            var typeParamCount = Math.Max(localTypeParamCount, localTypeArgCount);
            if (typeArgs == null)
                typeArgs = new List<Type>(typeInfo.GetTypeInfo().GenericTypeArguments);
            if (typeInfo.IsNested)
            {
                BuildCSharpFullName(typeInfo.DeclaringType, typeArgs, result);
            }
            else
            {
                result.Append(typeInfo.Namespace);
            }
            result.Append(".");
            foreach (var c in typeInfo.Name)
            {
                if (c == '`') //we found a generic
                    break;
                result.Append(c);
            }
            if (localTypeParamCount > 0)
            {
                result.Append("<");
                for (int i = 0; i < localTypeParamCount; i++)
                {
                    if (i > 0)
                        result.Append(",");
                    BuildCSharpFullName(typeArgs[i], null, result); //note that we are "eating" the typeArgs that we passed to us from the nested type.
                }
                typeArgs.RemoveRange(0, localTypeParamCount); //remove the used args
                result.Append(">");
            }
            else if (localTypeArgCount > 0 && typeArgs.Count > 0)
            {
                result.Append("<");
                for (int i = 0; i < Math.Min(localTypeArgCount, typeArgs.Count); i++)
                {
                    if (i > 0)
                        result.Append(",");
                    BuildCSharpFullName(typeArgs[i], null, result);
                }
                result.Append(">");
            }
        }
