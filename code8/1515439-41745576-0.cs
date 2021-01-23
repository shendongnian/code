    public static void DrawEllipse( char c, int centerX, int centerY, int width, int height )
    {
        for( int i = 0; i < width; i++ )
        {
            int dx = i - width / 2;
            int x = centerX + dx;
            
            int h = (int) Math.Round( height * Math.Sqrt( width * width / 4.0 - dx * dx ) / width );
            for( int dy = 1; dy <= h; dy++ )
            {
                Console.SetCursorPosition( x, centerY + dy );
                Console.Write( c );
                Console.SetCursorPosition( x, centerY - dy );
                Console.Write( c );
            }
            if( h >= 0 )
            {
                Console.SetCursorPosition( x, centerY );
                Console.Write( c );
            }
        }
    }
