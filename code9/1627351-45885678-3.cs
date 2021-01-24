        public class TableRowDTO
        {
            [JsonConverter(typeof(SqlGeographyConverter))]
            public SqlGeography f1 { get; set; }
            public int id { get; set; }
        }
    Where `SqlGeographyConverter` is, as required, a custom `JsonConverter` for `SqlGeography`.
    And then do:
		var settings = new JsonSerializerSettings().AddSqlConverters();
		var list = JsonConvert.DeserializeObject<List<TableRowDTO>>(jsonString, settings);
