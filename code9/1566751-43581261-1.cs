    BsonDocument result = GetID(doc, "90228c56-eff2-46d2-a324-b04e3c69e15c");
     public static BsonDocument GetID(BsonDocument doc, string queryId)
        {
            BsonDocument result = new BsonDocument();
            if (doc.Elements.Where(c => c.Name == "Setores").Count() != 0)
            {
                foreach (var item in doc.GetElement("Setores").Value.AsBsonArray)
                {
                    var id = item.AsBsonDocument.GetElement("Id").Value;
                    if (id == queryId)
                    {
                        result = item.AsBsonDocument;
                        break;
                    }
                    result = GetID(item.AsBsonDocument, queryId);
                }
            }
            return result;
        }
