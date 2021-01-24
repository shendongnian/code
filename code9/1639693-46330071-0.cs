        public static void Main(string[] args)
        {
            string someJson = 
                "{ "+
                "  \"invoicenr\": \"315.80042\", " +
                "  \"invoiceid\": 3474838, " +
                "  \"invoicedate\": \"2017 -09-20T00:00:00+02:00\"," +
                "  \"invoicetype\": \"C\", " +
                "  \"invoicemethod\": \"I\", " +
                "  \"invoicemailby\": \"M\"," +
                "  \"amountex\": -0.01," +
                "  \"amountin\": 0," +
                " \"someArray\" : [1,2,3]" +
                "}";
            var results = JObject.Parse(someJson);
            foreach(JProperty p in results.Properties())
            {
                //what kind of property is this?
                //Console.WriteLine(p.Type);
                JToken t = p.Value;
                //handle different data types..
                if(p.Type == JTokenType.Property)
                {
                    //todo..
                    if (p.HasValues && t.Children().ToList().Count > 0)
                    {
                        var elems = t.Children();
                        foreach (var elem in elems)
                        {
                            Console.Write(elem.Value<int>());
                        }
                    } else
                    {
                        Console.Write(t);
                    }
                } else if(p.Type == JTokenType.Object)
                {
                    //todo...
                    JEnumerable<JToken> subProperties = p.Value.Children();
                    //do something with it, maybe recursively..
                }
                else
                {
                    //everything else we try to print directly..
                    Console.Write(t);
                }
            }
            Console.ReadLine();
        }
