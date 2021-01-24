     private static void handleArray(JProperty array)
        {
            //voor de gewone array:
            foreach (JArray x in array)
            {
                foreach (var a in x)
                    if(a.Type == JTokenType.Object)
                    {
                        Console.WriteLine("Array with objects!");
                    }
                    else
                    {
                        Console.WriteLine((string) a);
                    }
                    
                
            }
