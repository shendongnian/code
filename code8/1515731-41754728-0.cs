    public static class MyTokenReaderUtilities
    {
         public static void DoMyFunction(JToken token, Func<string, JToken> convertString)
         {
            switch (token.Type)
            {
                case JTokenType.Array:          
                   JArray array = token as JArray;
                  array.ForEach(a => DoMyFunction(a, convertString));
                  break;           
               case JTokenType.String:
                 token.Replace(convertString(token.ToString()));
               break;
              case JTokenType.Object:
                  token.Children().ForEach(t => DoMyFunction(t, convertString));
                  break;
              case JTokenType.Property:
                  JProperty prop = token as JProperty;
                  if (prop.Value.Type == JTokenType.Array)
                  {
                    DoMyFunction(prop.Value, convertString);
                    return;
                  }
                  prop.Value = convertString(prop.Value.ToString());
                  break;
              default:
                 throw new NotImplementedException(token.Type + " is not defined");
           }  
         }
    }
