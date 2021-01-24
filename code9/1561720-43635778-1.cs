    public object returnDLLObject(string MethodName)
            {
                string className = "CustomeReports.CustomReports";
                object result = null;
                object classInstance = null;
                string path = Server.MapPath(@"../CustomReports/CustomeReports.dll");
    
               // if (!FileOrDirectoryExists(path))
                assembly = Assembly.LoadFrom(path);
    
                if (FileOrDirectoryExists(path))
                {
                    try
                    {
                        Type _type_2 = assembly.GetType(className);
                        var methodInfo = _type_2.GetMethod(MethodName);
                        ParameterInfo[] parameters = methodInfo.GetParameters();
                        classInstance = Activator.CreateInstance(_type_2, null);
                        if (parameters.Length == 0)
                        {
                            result = methodInfo.Invoke(classInstance, null);
                        }
                        else
                        {
                            object[] parametersArray = new object[] { ViewState["nodevalue"].ToStringIC() };
                            result = methodInfo.Invoke(classInstance, parametersArray);
                        }
                    }
                    catch (Exception ex)
                    {
                        //Error.BLErrorDesc = ex.Message;
                        result = null;
                    }
                }
                return result;
            }
