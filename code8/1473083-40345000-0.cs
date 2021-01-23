    // System.Data.Entity.Migrations.Design.CSharpMigrationCodeGenerator
    /// <summary>
    /// Quotes an identifier using appropriate escaping to allow it to be stored in a string.
    /// </summary>
    /// <param name="identifier"> The identifier to be quoted. </param>
    /// <returns> The quoted identifier. </returns>
    protected virtual string Quote(string identifier)
    {
    	return "\"" + identifier + "\"";
    }
