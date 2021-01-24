    public class FunnyListConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var content = new List<Content>();
            var currentType = "";
            Invoice currentInvoice = null;
            Receipt currentReceipt = null;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndArray)
                {
                    break;
                }
                if (reader.Value?.ToString() == "invoice")
                {
                    currentInvoice = new Invoice();
                    currentType = "invoice";
                }
                if (reader.Value?.ToString() == "receipt")
                {
                    currentReceipt = new Receipt();
                    currentType = "receipt";
                }
                if (reader.Path.Contains("DFID") && reader.Value?.ToString() != "DFID")
                {
                    switch (currentType)
                    {
                        case "invoice":
                            currentInvoice.DFID = int.Parse(reader.Value.ToString());
                            content.Add(currentInvoice);
                            currentInvoice = null;
                            break;
                        case "receipt":
                            currentReceipt.DFID = int.Parse(reader.Value.ToString());
                            content.Add(currentReceipt);
                            currentReceipt = null;
                            break;
                    }
                }
            }
            return content;
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
              }
                if (reader.Value?.ToString() == "receipt")
                {
                    currentReceipt = new Receipt();
                    currentType = "receipt";
                }
                if (reader.Path.Contains("DFID") && reader.Value?.ToString() != "DFID")
                {
                    switch (currentType)
                    {
                        case "invoice":
                            currentInvoice.DFID = int.Parse(reader.Value.ToString());
                            content.Add(currentInvoice);
                            currentInvoice = null;
                            break;
                        case "receipt":
                            currentReceipt.DFID = int.Parse(reader.Value.ToString());
                            content.Add(currentReceipt);
                            currentReceipt = null;
                            break;
                    }
                }
            }
            return content;
        }
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
