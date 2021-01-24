    public static void myMethod(String myArray)
    {
       dynamic jsonResponse = JsonConvert.DeserializeObject(myArray);
       for (var i = 0; i < jsonResponse.Count; i++)
       {
           ...........
       }
    }
