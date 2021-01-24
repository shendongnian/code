    public class DoDatabaseStuff() {
        private IMagic _magic
        public DoDatabaseStuff(bool useNoSql) {
           _magic = MagicFactory.GetMagic(useNoSql);
           ITable myTable = _magic.CreateTable("CustomerTable");
           myTable.AddColumn(typeof(int), "ID");
           myTable.AddColumn(typeof(string), "Name");
       }
    }
