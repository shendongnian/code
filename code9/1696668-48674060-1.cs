    private void updateValesPonyNumeroFactura(ref string error)
        {
            string pathFile = @"c:\Temp\";
            OleDbConnection con = new OleDbConnection(GetConnection(pathFile));
            try
            {
                string updateRow = $"UPDATE vale.dbf SET Factura = 'c00001' WHERE vale = '011395'";
                OleDbCommand cmd = new OleDbCommand(updateRow, con);
                con.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "MyTable");
                con.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }
        private static string GetConnection(string path)
        {
            return $"Provider=vfpoledb;Data Source={path};Collating Sequence=machine;";
        }
