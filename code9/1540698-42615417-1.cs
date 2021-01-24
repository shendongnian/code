    [ProtoContract]
    internal class NotACollectionHolderSurrogate
    {
        [ProtoMember(1)]
        internal NotACollectionSurrogate some_objects;
        public static implicit operator NotACollectionHolder(NotACollectionHolderSurrogate input)
        {
            if (input == null)
                return null;
            return new NotACollectionHolder { some_objects = input.some_objects };
        }
        public static implicit operator NotACollectionHolderSurrogate(NotACollectionHolder input)
        {
            if (input == null)
                return null;
            return new NotACollectionHolderSurrogate { some_objects = input.some_objects };
        }
    }
    [ProtoContract]
    internal class NotACollectionSurrogate
    {
        [ProtoMember(1)]
        public int some_data;
        public static implicit operator NotACollection(NotACollectionSurrogate input)
        {
            if (input == null)
                return null;
            return new NotACollection { some_data = input.some_data };
        }
        public static implicit operator NotACollectionSurrogate(NotACollection input)
        {
            if (input == null)
                return null;
            return new NotACollectionSurrogate { some_data = input.some_data };
        }
    }
