    internal static Type[] KnownInterfaces
            {
                get
                {
                    if (_knownInterfaces == null)
                    {
                        // Listed in priority order
                        _knownInterfaces = new Type[]
                    {
                        Globals.TypeOfIDictionaryGeneric,
                        Globals.TypeOfIDictionary,
                        Globals.TypeOfIListGeneric,
                        Globals.TypeOfICollectionGeneric,
                        Globals.TypeOfIList,
                        Globals.TypeOfIEnumerableGeneric,
                        Globals.TypeOfICollection,
                        Globals.TypeOfIEnumerable
                    };
                    }
                    return _knownInterfaces;
                }
            }
