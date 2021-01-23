    // this is DbContext here
    private void ObjectContextOnObjectMaterialized(object sender, ObjectMaterializedEventArgs objectMaterializedEventArgs) {
        var dbName = objectMaterializedEventArgs.Entity as IHasDatabaseName;
        if (dbName != null) {
            dbName.Database = this.Database.Connection.Database;
        }
    }
