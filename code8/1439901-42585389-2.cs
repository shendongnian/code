    public myObjectType ConvertStringToObject<myObjectType>(string CarObjectString, string myObjectName)
            {
                myObjectType myObject = (myObjectType)Activator.CreateInstance(Type.GetType(myObjectName));
                var js = new DataContractJsonSerializer(typeof(myObjectType));
                byte[] byteArray = Encoding.UTF8.GetBytes(CarObjectString);
                var ms = new MemoryStream(byteArray);
                myObject = (myObjectType)js.ReadObject(ms);
                return myObject;
            }
        }
    }
