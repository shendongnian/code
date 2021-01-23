    public static Dictionary<String,List<HttpPostedFileBase>> GetFilesAsDictionary( HttpFileCollection files ) {
        
        Dictionary<String,List<HttpPostedFileBase>> dict = Dictionary<String,List<HttpPostedFileBase>>;
        
        for( int i = 0 ; i < files.Count; i++ ) {
            String key = file.GetKey( i );
                        
            List<HttpPostedFileBase> list;
            if( !dict.TryGetValue( key, out list ) ) {
                dict.Add( key, list = new List<HttpPostedFileBase>() );
            }
            list.Add( files[i] );
        }
        
        return dict;
    }
