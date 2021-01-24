        public class TableRowDTO
        {
            public SqlGeography f1 { get; set; }
            public int id { get; set; }
        }
    And then do:
		var settings = new JsonSerializerSettings().AddSqlConverters();
		var list = JsonConvert.DeserializeObject<List<TableRowDTO>>(jsonString, settings);
