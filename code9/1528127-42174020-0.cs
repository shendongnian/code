    class Program
    {
        static int _caseOneCount = 0;
        static int _caseTwoCount = 0;
    
        static Random _rnd = new Random();
    
        static void Main( string[] args )
        {
            var max = 100000;
    
            for ( var i = 0 ; i < max ; i++ )
            {
                CaseOne();
                CaseTwo();
    
                Console.WriteLine( _caseOneCount.ToString() + "/" + _caseTwoCount.ToString() );
            }
        }
    
        static void CaseOne()
        {
            if ( _rnd.Next( 5 ) == 0 )
                _caseOneCount++;
        }
    
        static void CaseTwo()
        {
            for ( var i = 0 ; i < 10 ; i++ )
                if ( _rnd.Next( 50 ) == 0 )
                    _caseTwoCount++;
        }
    }
