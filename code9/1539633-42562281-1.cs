    static Dictionary<int, Emp> ConvertToDict(DataTable dt)
        {
            Dictionary<int, Emp> emps = new Dictionary<int, Emp>();
            foreach (var dr in dt.AsEnumerable())
            {
                var id = (int)dr["ID"];
                var name = (string)dr["Name"];
                var cardTypeName = (string)dr["CardTypeName"];
                var exp = (int)dr["Exp"];
                Emp emp;
                var cardType = new CardType { Name = cardTypeName, Exp = exp };
                if (emps.TryGetValue(id, out emp))
                {
                    emp.CardTypes.Add(cardType);
                }
                else
                {
                    emps.Add(id, new Emp { ID = id, Name = name, CardTypes = new List<CardType> { cardType } });
                }
            }
            return emps;
        }
        static List<string> Serialize<T>(IEnumerable<T> entities) where T:new()
        {
            var ser = new XmlSerializer(typeof(T));
            
            var serializedEntities = entities.Select(entity =>
            {
                using (var sw = new StringWriter())
                {
                    ser.Serialize(sw, entity);
                    return sw.ToString();
                }
            }).ToList();
            return serializedEntities;
        }
