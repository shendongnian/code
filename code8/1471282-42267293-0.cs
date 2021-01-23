    SQLiteConnection con = new SQLiteConnection(@"myDB.db");
    SQLitePCL.raw.sqlite3_create_function(con.Handle, "REGEXP", 2, null, MatchRegex);
    private void MatchRegex(sqlite3_context ctx, object user_data, sqlite3_value[] args)
        {
            bool isMatched = System.Text.RegularExpressions.Regex.IsMatch(SQLitePCL.raw.sqlite3_value_text(args[1]), SQLitePCL.raw.sqlite3_value_text(args[0]),RegexOptions.IgnoreCase);
            if (isMatched)
                SQLitePCL.raw.sqlite3_result_int(ctx, 1);
            else
                SQLitePCL.raw.sqlite3_result_int(ctx, 0);
        }
