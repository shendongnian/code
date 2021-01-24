        private static void WriteImage(MemoryStream ms, int RowId)
            {
                var conf = ConfigurationManager.ConnectionStrings["SQLconnString"].ToString();
                //Added using
                using(SqlConnection writecon = new SqlConnection(conf))
    {
    
                writecon.Open();
    
                using (FileStream file = new FileStream("after.jpg", FileMode.Create, System.IO.FileAccess.Write))
                {
                    file.Write(ms.ToArray(), 0, (int)ms.Length);
                }
    
                using (SqlCommand cmd = new SqlCommand("UPDATE InspectionItem SET strIIImage = @Image WHERE intIIID = @Id", writecon))
                {
                    cmd.Parameters.Add("@Image", SqlDbType.VarBinary, (int)ms.Length).Value = ms.ToArray();
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = RowId;
                    cmd.CommandTimeout = 5;
                    try
                    { //This is where it breaks. :)
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Writeout(e.Message + "Error occured on row: " + RowId);
                        return;
                    }
                }
                Writeout("Succesfully Resized File: " + RowId);
                }
            }
