    using Microsoft.SqlServer.TransactSql.ScriptDom;
    ....
     
    TSql120Parser SqlParser = new TSql120Parser(false);
     
    IList<ParseError> parseErrors;
    TSqlFragment result = SqlParser.Parse(new StringReader(SqlTextBox.Text),
                                          out parseErrors);
     
    TSqlScript SqlScript = result as TSqlScript;
     
    foreach (TSqlBatch sqlBatch in SqlScript.Batches)
    {
       foreach (TSqlStatement sqlStatement in sqlBatch.Statements)
       {
          ProcessViewStatementBody(sqlStatement);
       }
    }
