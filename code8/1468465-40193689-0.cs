    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dtFirst = new DataTable();
                dtFirst.Columns.Add("Fieldname", typeof(string));
                dtFirst.Columns.Add("Newvalue", typeof(int));
                dtFirst.Columns["Newvalue"].AllowDBNull = true;
                dtFirst.Rows.Add(new object[] {"antenastructure", 12});
                dtFirst.Rows.Add(new object[] {"slno", 2});
                dtFirst.Rows.Add(new object[] {"servicelevel"});
                dtFirst.Rows.Add(new object[] {"powersupply"});
                string[] dtFirstValidRows = dtFirst.AsEnumerable().Where(x => x.Field<int?>("Newvalue") != null).Select(x => x.Field<string>("Fieldname")).ToArray();
                DataTable dtMaster = new DataTable();
                dtMaster.Columns.Add("Mastertabe", typeof(string));
                dtMaster.Columns.Add("Masterfield", typeof(string));
                dtMaster.Columns.Add("infoid", typeof(int));
                dtMaster.Columns["infoid"].AllowDBNull = true;
                dtMaster.Columns.Add("zvalue", typeof(int));
                dtMaster.Columns["zvalue"].AllowDBNull = true;
                dtMaster.Columns.Add("qvalue", typeof(int));
                dtMaster.Columns["qvalue"].AllowDBNull = true;
                dtMaster.Rows.Add(new object[] {"M_seq", "antenastructure", 123});          
                dtMaster.Rows.Add(new object[] {"M_seq", "slno", 1});          
                dtMaster.Rows.Add(new object[] {"M_seq", "servicelevel", 133});          
                dtMaster.Rows.Add(new object[] {"M_seq", "powersupply", 154});          
                dtMaster.Rows.Add(new object[] {"M_seq", "azimheight", 124});
                dtMaster = dtMaster.AsEnumerable().Where(x => dtFirstValidRows.Contains(x.Field<string>("Masterfield"))).CopyToDataTable();
            }
        }
    }
