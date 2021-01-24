    public static double CREDIT()
    {
        try
        {
            string req = "select SUM(F.Reste) "+
                            "from RELATION as R "+
                            "inner join Facture as F "+
                            "ON R.NRelation = F.Relation";
            using (var con = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand(req, con))
                {
                    con.Open();
                    var value = cmd.ExecuteScalar();
                    double total;
                    if (value != null && value != DBNull.Value && double.TryParse(value.ToString(), out total))
                    {
                        return total;
                    }
                }
            }
        }
        catch (SqlException E)
        {
            MessageBox.Show(E.Message, "<!!!>", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return 0;
    }
