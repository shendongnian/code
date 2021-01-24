    [Obsolete("Please specify parameters separately - use 'null' if no parameters are needed")]
    SomeFunction(string table, string column, string where) {
        return SomeFunction(table, column, where, null);
    }
    SomeFunction(string table, string column, string where, object args) {
        // ...
    }
