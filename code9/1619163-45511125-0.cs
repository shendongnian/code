    class PersonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Person);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Person person = (Person)value;
            JObject result = new JObject();
            result.Add("id", person.Id);
            result.Add("fullname", (person.FirstName + " " + person.LastName).Trim());
            result.Add("address", (person.Address1 + " " + person.Address2).Trim());
            result.WriteTo(writer);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            Person person = new Person();
            person.Id = (int)obj["id"];   // assuming id will always be present in the JSON
            string fullName = (string)obj["fullname"];
            if (fullName != null)
            {
                string[] parts = fullName.Split(new char[] { ' ' }, 2);
                // if there's only 1 part, I'm assuming it is the first name
                if (parts.Length > 0)
                    person.FirstName = parts[0];
                if (parts.Length > 1)
                    person.LastName = parts[1];
            }
            person.Address1 = (string)obj["address"];  // don't bother trying to split address
            return person;
        }
    }
