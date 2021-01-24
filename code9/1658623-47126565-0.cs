    public class TableDAO
    {
        public DataTable GetClients()
        {
            var clientTable = new DataTable("tblClients");
            clientTable.Columns.Add("id", typeof(int));
            clientTable.Columns.Add("name", typeof(string));
            clientTable.Columns.Add("gradientParams", typeof(string));
            clientTable.Columns.Add("gradClass", typeof(string));
            var row = clientTable.NewRow();
            row[0] = 1;
            row[1] = "Kakaroto";
            row[2] = "left,red,orange,yellow,green,blue,indigo,violet";
            row[3] = "grad1";
            clientTable.Rows.Add(row);
            row = clientTable.NewRow();
            row[0] = 2;
            row[1] = "Vegeta";
            row[2] = "right,rgba(255,0,0,0),rgba(255,0,0,1)";
            row[3] = "grad2";
            clientTable.Rows.Add(row);
            row = clientTable.NewRow();
            row[0] = 3;
            row[1] = "Broly";
            row[2] = "-90deg, red, yellow";
            row[3] = "grad3";
            clientTable.Rows.Add(row);
            return clientTable;
        }
    }
    
