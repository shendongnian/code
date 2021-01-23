    public class ChangeLogConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ICollection<TransactionChange>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<TransactionChange> changes = new List<TransactionChange>();
            JObject changelog = JObject.Load(reader);
            foreach (JProperty dateProp in changelog.Children<JProperty>())
            {
                DateTime changeDate = DateTime.ParseExact(dateProp.Name, "yyyy-MMM-dd hh:mm tt", CultureInfo.InvariantCulture);
                foreach (JProperty fieldProp in dateProp.Value.Children<JProperty>())
                {
                    TransactionChange change = new TransactionChange();
                    change.ChangeDate = changeDate;
                    change.Field = fieldProp.Name;
                    change.From = (string)fieldProp.Value["from"];
                    change.To = (string)fieldProp.Value["to"];
                    changes.Add(change);
                }
            }
            return changes;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
