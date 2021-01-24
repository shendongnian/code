    for ( int i = 0; i < objectList.Count(); i++ )
    {
        var iObj = objectList[i];
        for ( int j = i ; j < objectList.Count(); j++ )
        {
            var jObj = objectList[j];
            if ( iObj.collideWith(jObj) )
            {
                Collision( iObj, jObj );
            }
        }
    }
