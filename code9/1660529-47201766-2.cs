    public void CreateTables(IEnumerable<Type> types) {
        if(types != null) {
            foreach(Type type in types) {
                CreateTables(type);
            }
        }
    }
