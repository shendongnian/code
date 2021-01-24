    /// <summary>
    /// Persistence Technology independent BO.
    /// </summary>
    public abstract class BusinessObjectX
    {
        internal BusinessObjectX()
        {
        }
        public abstract string SomeProperty { get; }
    }
    /// <summary>
    /// Technology independent repository abstraction for BOX - Create could
    /// be a static member of <see cref="BusinessObjectX"/>
    /// </summary>
    public abstract class BusinessObjectXRepoAbstraction
    {
        public abstract BusinessObjectX Create(string mandatoryPropertyValue);
    }
