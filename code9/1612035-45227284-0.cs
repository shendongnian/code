        public static void Executar(string namespaceClass, string metodo, List<Parametros> parametros = null)
        {
            Type type = Type.GetType(namespaceClass);
            MethodInfo methodInfo = type.GetMethod(metodo);
            Object objectToInvoke;
            if (type.IsAbstract && type.IsSealed)
            {
                objectToInvoke = type;
            }
            else {
                objectToInvoke = Activator.CreateInstance(type);
            }
            ParameterInfo[] parametersFromMethod = methodInfo.GetParameters();
            if (parametros != null || (methodInfo != null && parametersFromMethod != null && parametersFromMethod.Length > 0))
            {
                List<object> myParams = new List<object>();
                foreach (ParameterInfo parameterFound in parametersFromMethod)
                {
                    Parametros parametroEspecificado = parametros.Where(p => p.name == parameterFound.Name).FirstOrDefault();
                    if (parametroEspecificado != null)
                    {
                        myParams.Add(parametroEspecificado.value);
                    }
                    else
                    {
                        myParams.Add(null);
                    }
                }
                methodInfo.Invoke(objectToInvoke, myParams.ToArray());
            }
            else
            {
                methodInfo.Invoke(objectToInvoke, null);
            }
        }
