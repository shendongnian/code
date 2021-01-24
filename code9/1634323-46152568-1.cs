    //     The connection to the database (including the name of the database)
    //     can be specified in several ways.  If the parameterless DbContext constructor
    //     is called from a derived context, then the name of the derived context is
    //     used to find a connection string in the app.config or web.config file. If
    //     no connection string is found, then the name is passed to the DefaultConnectionFactory
    //     registered on the System.Data.Entity.Database class. The connection factory
    //     then uses the context name as the database name in a default connection string.
    //     (This default connection string points to .\SQLEXPRESS on the local machine
    //     unless a different DefaultConnectionFactory is registered.) Instead of using
    //     the derived context name, the connection/database name can also be specified
    //     explicitly by passing the name to one of the DbContext constructors that
    //     takes a string. The name can also be passed in the form "name=myname", in
    //     which case the name must be found in the config file or an exception will
    //     be thrown.  Note that the connection found in the app.config or web.config
    //     file can be a normal database connection string (not a special Entity Framework
    //     connection string) in which case the DbContext will use Code First.  However,
    //     if the connection found in the config file is a special Entity Framework
    //     connection string, then the DbContext will use Database/Model First and the
    //     model specified in the connection string will be used.  An existing or explicitly
    //     created DbConnection can also be used instead of the database/connection
    //     name.
