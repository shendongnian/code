    public static Dictionary<int, Item> Load(string path)
            {
                //var xml = Resources.Load<TextAsset>(path);
                XmlSerializer serializer = new XmlSerializer(typeof(Items));
                StreamReader reader = new StreamReader(path);
                Items items = (Items)serializer.Deserialize(reader);
                reader.Close();
                Dictionary<int, Item> dict = items.items.GroupBy(x => x.Id).ToDictionary(x => x.Key, y => y.FirstOrDefault());
                return dict;
            }
