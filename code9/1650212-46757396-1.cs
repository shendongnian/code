    using Microsoft.SqlServer.TransactSql.ScriptDom;
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace MyApp
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var sql = @"
    SELECT columnA
    FROM   tblB
    WHERE  ColumnB = 1
    
    DELETE tblD
    WHERE  ID = '100'
    
    INSERT INTO tblF
                (NAME)
    VALUES      ('test'),
                ('foo'),
                ('bar') 
    ";
    
                var parser = new TSql100Parser(true); //Or TSql120Parser or whatever
                IList<ParseError> errors = new List<ParseError>();
    
                TSqlScript script = (TSqlScript)parser.Parse(new StringReader(sql), out errors);
                //TODO: Don't ignore errors
                foreach (var batch in script.Batches)
                {
                    foreach (var st in batch.Statements)
                    {
                        Console.WriteLine(st.GetType().Name);
                        Console.WriteLine(sql.Substring(st.StartOffset, st.FragmentLength));
                        Console.WriteLine();
                    }
                }
            }
        }
    }
