    class Foo
    {
        private List<Object> _myList;
        IReadOnlyList<Object> MyList => _myList.AsReadOnly();
        // or IReadOnlyCollection. 
        // Items in a IReadOnlyList are accessible by index.
    }
