    public class JSONConverter
        {
            public string Convert(List<RootObject> list)
            {
                return JsonConvert.SerializeObject(list);
            }
        }
