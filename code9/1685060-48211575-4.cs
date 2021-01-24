    /// <summary>
    /// Example of use.
    /// </summary>
    public static class UseExample
    {
        public static BusinessObjectX DoStuff(BusinessObjectXRepoAbstraction repo)
        {
            var newBox = repo.CreateX("mandatory property");
            //Do stuff...
            return newBox;
        }
    }
