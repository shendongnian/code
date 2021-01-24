    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.updateTable("1", @"\\share\from\path", @"\\share\to\path");
            Console.ReadLine();
        }
        private void updateTable(string id, string fromFolder, string toFolder)
        {
            string str = @"update my_document " +
                        "set path = replace (path,'" + fromFolder + "','" + toFolder + "')" +
                        "where doc_id in( select doc_id from patient_document where folder_id='" + id + "')";
            str.Replace("\\", "\\\\");
            Console.WriteLine(str);
            using (MySqlConnection conn = new MySqlConnection(ECModel.Instance.ConnString))
            {
                using (MySqlCommand cmd = new MySqlCommand(str, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
