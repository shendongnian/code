    [TableName("Administrators")]
    [PrimaryKey("dbid", autoIncrement = true)]
    class Administrators
    {
        public int dbid { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
