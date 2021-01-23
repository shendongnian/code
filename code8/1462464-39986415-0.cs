        public class MyGenericControllerFactory : DefaultControllerFactory
        {
            public override IController CreateController(RequestContext reqContext, string controllerName)
            {
                if(is controlleName generic) //you should define how build controller name when is generic
                //it should contain the controller name and the generic type name
                {
                    string contRealName = "";//get the real controller name from controllerName var
                    string genTypeName = ""; //get the generic type name fomr controllerName var
                    Type contType = Type.GetType(contRealName);
                    Type genType = Type.GetType(genTypeName);
                    contType = contType.MakeGenericType(genType);
                    return an instance of contType from your IoC container
                }
                else
                {
                    Type contType = Type.GetType(controllerName);
                    return an instance of contType from your IoC container
                }
            }
        }
