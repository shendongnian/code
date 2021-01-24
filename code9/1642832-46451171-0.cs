    class Program
    {
        static void Main( string[ ] args )
        {
            string[ ] str = { "A", "B", "C", "D", "E" };
            foreach( var v in str )
            {
                MakeThreadModified( v );
            }
            Console.ReadLine( );
        }
        public static void MakeThreadModified( string s )
        {
            new Thread( obj =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                while( true )
                {
                    Console.WriteLine( $"[{Thread.CurrentThread.ManagedThreadId}] {( string )obj}" );
                    Thread.Sleep( 500 );
                }
            } ).Start( s );
        }
    }
