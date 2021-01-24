    using MyNamespace;
    namespace MyNamespace.Data
    {
        using MyNamespace.Domain;
        // or alternatively, because Domain is part of MyNamespace
        using Domain;
        public class MyDbContext : DbContext { }
    }
