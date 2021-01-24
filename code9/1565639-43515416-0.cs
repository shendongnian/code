    string[] accceptedColumns = {"a", "b", "c" };
    string[] lines = File.ReadAllLines( path );
    foreach ( var columnName in lines[0].Split( ',' ) )
    {
        if ( !accceptedColumns.Contains( columnName ) )
        {
            //Invalid column
        }
    }
