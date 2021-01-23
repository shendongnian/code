    SqlConnection conn = new SqlConnection("Your Connection Settings");
    string command="Select NoteId, NoteName, Note FROM Notes";
    SqlDataAdapter da = new SqlDataAdapter(command, conn);
    DataTable dt = new DataTable();
    da.Fill(dt);
