    public class DoDatabaseStuff() {
        private IMagic _magic
        public DoDatabaseStuff(bool useNoSql) {
           IMagic magic = MagicFactory.GetMagic(useNoSql);
           ITable myTable = magic.CreateTable("CustomerTable");
           myTable.AddColumn(typeof(int), "ID");
           myTable.AddColumn(typeof(string), "Name");
       }
    }
