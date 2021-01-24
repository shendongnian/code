        public FileResult FileDownload(int id)
           {
            SqlConnection con = new SqlConnection(@"Server=10UR\MSSQLSERVERR;Database=UniversiteDB;UID=onur;PWD=1234");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT DersNotIcerik FROM Ders WHERE DersId=@Id";
            cmd.Parameters.AddWithValue("@Id", id);
            byte[] binaryData = (byte[])cmd.ExecuteScalar();
            return File(binaryData, "application/octet-stream", "DersNot.pdf");
        }
