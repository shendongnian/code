	public sealed class MyClassMap : CsvClassMap<MyClass>
	{
	    public MyClassMap()
	    {
	        Map( m => m.Description ).Index( 0 )
                               .TypeConverterOption( CultureInfo.InvariantCulture );
	        Map( m => m.TimeStamp ).Index( 1 )
                              .TypeConverterOption( DateTimeStyles.AdjustToUniversal );
	        Map( m => m.Cost ).Index( 2 )
                              .TypeConverterOption( NumberStyles.Currency );
	        Map( m => m.CurrencyFormat ).Index( 3 )
                              .TypeConverterOption( "C" );
	        Map( m => m.BooleanValue ).Index( 4 )
                              .TypeConverterOption( true, "sure" )
                              .TypeConverterOption( false, "nope" );
	    }
	}
