    private static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader(@"C:\Folder\myjson.json"))
            {
                string json = sr.ReadToEnd();
                JsonDoc jSon = new JsonDoc(json);
                //This will get the length of the array under ClaimList node
                int intCount = jSon.intCount;
                List<JsonDoc> lstResult = new List<JsonDoc>();
                for (int x = 0; x < intCount; x++)
                {
                    lstResult.Add(new JsonDoc(json, x));
                }
            }
        }
