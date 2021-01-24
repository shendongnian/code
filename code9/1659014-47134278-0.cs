    // Don't forget to add `using System.Linq;` at the beginning of your file
    public float mscore = 5 ;
    public float hscore = 10 ;
    private System.Collections.Generic.List<System.Reflection.FieldInfo> fields ;
    private System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex( "@[a-zA-Z0-9]+" );
    private void Awake()
    {
        var bindingFlags = System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Public;
        fields = GetType().GetFields( bindingFlags )
                        .Where( fieldInfo => fieldInfo.FieldType == typeof( float ) ) // Use this if you want to retrieve only the floating variables
                        .ToList();
        Debug.Log( ReplaceInput( "my score is @mscore , his score is @hscore" ) );
    }
    public string ReplaceInput( string input )
    {
        string output = input;
        System.Text.RegularExpressions.MatchCollection matches = regex.Matches( input );
        for ( int i = 0 ; i < matches.Count ; i++ )
        {
            string fieldName = matches[i].Value.Substring(1);
            var fieldInfo = fields.Find( field => field.Name.CompareTo( fieldName ) == 0 );
            if ( fieldInfo != null )
                output = output.Replace( matches[i].Value, fieldInfo.GetValue( this ).ToString() );
        }
        return output;
    }
    // Use this function to retrieve the list of variables you can use when you start typing
    public System.Collections.Generic.List<string> GetVariables( string input )
    {
        return fields.FindAll( field => field.Name.StartsWith( input ) ).Select( field => field.Name ).ToList();
    }
