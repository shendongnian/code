    // System.Data.Entity.Migrations.Design.CSharpMigrationCodeGenerator
    private void WriteIndexParameters(CreateIndexOperation createIndexOperation, IndentedTextWriter writer)
    {
    	if (createIndexOperation.IsUnique)
    	{
    		writer.Write(", unique: true");
    	}
    	if (createIndexOperation.IsClustered)
    	{
    		writer.Write(", clustered: true");
    	}
    	if (!createIndexOperation.HasDefaultName)
    	{
    		writer.Write(", name: ");
    		writer.Write(this.Quote(createIndexOperation.Name));
    	}
    }
