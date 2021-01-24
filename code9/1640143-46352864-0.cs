    public class DataSetConverter<TDataTableConverter> : DataSetConverter where TDataTableConverter : JsonConverter, new()
    {
        // This code adapted from 
        // https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Converters/DataSetConverter.cs
        // Copyright (c) 2007 James Newton-King
        // Licensed under The MIT License (MIT):
        // https://github.com/JamesNK/Newtonsoft.Json/blob/master/LICENSE.md
        readonly TDataTableConverter converter = new TDataTableConverter();
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            // handle typed datasets
            DataSet ds = (objectType == typeof(DataSet))
                ? new DataSet()
                : (DataSet)Activator.CreateInstance(objectType);
            reader.ReadAndAssert();
            while (reader.TokenType == JsonToken.PropertyName)
            {
                DataTable dt = ds.Tables[(string)reader.Value];
                bool exists = (dt != null);
                dt = (DataTable)converter.ReadJson(reader, typeof(DataTable), dt, serializer);
                if (!exists)
                {
                    ds.Tables.Add(dt);
                }
                reader.ReadAndAssert();
            }
            return ds;
        }
    }
    public static class JsonReaderExtensions
    {
        public static void ReadAndAssert(this JsonReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException();
            if (!reader.Read())
            {
                new JsonReaderException(string.Format("Unexpected end at path {0}", reader.Path));
            }
        }
    }
