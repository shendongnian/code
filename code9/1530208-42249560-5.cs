    class MyClass<T>
    {
        public void X<Q>(Q q) where Q: NamedEntity { ... }
        public void X<Q>(Q q) where Q: KeyedEntitiy { ... }
    }
