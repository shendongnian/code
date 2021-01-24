    public List<StockHead> GetStockHead( string sql, params object[] args )
    {
        DataTable t;
        if ( args == null )
        {
            Console.WriteLine( "GetStockHead #1 - args are NULL " );
        }
        else
        {
            Console.WriteLine( "GetStockHead #2 - {0} arguments passed", args.Count() );
        }
    
        Accdb.ExecuteQuery( out t, sql, args );
    
        if ( t != null )
        {
            List<StockHead> shlist = new List<StockHead>();
    
            foreach ( DataRow r in t.Rows )
            {
                Console.WriteLine( t.ToString() );
                StockHead sh = new StockHead(
                    (int)r["sh_id"],
                    (string)r["sh_ref"],
                    (int)r["sh_lineno"],
                    (string)r["sh_type"],
                    (string)r["sh_supplier"],
                    (DateTime)r["sh_datetime"]);
                shlist.Add( sh );
            }
            return shlist;
        }
        else
        {
            Console.WriteLine( "GetStockHead #3 - t is null" );
            return null;
        }
    }
