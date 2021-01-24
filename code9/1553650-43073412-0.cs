    cmd.Parameters.Add(new OleDbParameter("@Title", OleDbType.WChar, 255, "Title"));
    cmd.Parameters.Add(new OleDbParameter("@CodeBefore", OleDbType.WChar, 0, "CodeBefore"));
    cmd.Parameters.Add(new OleDbParameter("@CodAfter", OleDbType.WChar, 0, "CodAfter"));
    cmd.Parameters.Add(new OleDbParameter("@Exp", OleDbType.WChar, 0, "Exp"));
    cmd.Parameters.Add(new OleDbParameter("@Example", OleDbType.WChar, 0, "Example"));
    cmd.Parameters.Add(new OleDbParameter("@Notes", OleDbType.WChar, 255, "Notes"));
    cmd.Parameters.Add(new OleDbParameter("@FixID", OleDbType.WChar, 20, "FixID"));
