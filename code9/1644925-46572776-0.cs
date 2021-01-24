    ...
     using System.DirectoryServices;
     ...
    
    /// <summary>
     /// Determines whether or not the specified user is a member of the group.
     /// </summary>
     /// <param name="UserDN">A System.String containing the user's distinguished name (DN).</param>
     /// <param name="Group">A System.DirectoryServices.DirectoryEntry object of the target group.</param>
     private Boolean IsMemberOfLargeGroup( String UserDN, DirectoryEntry Group )
     {
     Boolean userFound = false;
     Boolean isLastQuery = false;
     Boolean exitLoop = false;
     Int32 rangeStep = 1500;
     Int32 rangeLow = 0;
     Int32 rangeHigh = rangeLow + ( rangeStep - 1 );
     String attributeWithRange;
    
    DirectorySearcher groupSearch = new DirectorySearcher( Group );
     SearchResult searchResults;
    
    groupSearch.Filter = "(objectClass=*)";
    
    do
     {
     if( !isLastQuery )
     attributeWithRange = String.Format( "member;range={0}-{1}", rangeLow, rangeHigh );
     else
     attributeWithRange = String.Format( "member;range={0}-*", rangeLow );
    
    groupSearch.PropertiesToLoad.Clear();
     groupSearch.PropertiesToLoad.Add( attributeWithRange );
    
    searchResults = groupSearch.FindOne();
     groupSearch.Dispose();
    
    if( searchResults.Properties.Contains( attributeWithRange ) )
     {
     if( searchResults.Properties[ attributeWithRange ].Contains( userDN ) )
     userFound = true;
    
    if( isLastQuery )
     exitLoop = true;
     }
     else
     {
     isLastQuery = true;
     }
    
    if( !isLastQuery )
     {
     rangeLow = rangeHigh + 1;
     rangeHigh = rangeLow + ( rangeStep - 1 );
     }
     }
     while( ! ( exitLoop | userFound ) );
    
    return userFound;
     }
