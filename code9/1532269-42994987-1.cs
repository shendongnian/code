        static private readonly Action<Stream, T> m_Serialize;
        static Serializer()
        {
            Serializer<T>.m_Serialize = Expression.Lambda<Action<Stream, T>>(... [a lot of reflection here] ...).Compile();
        }
        public void Serialize(Stream stream, T value)
        {
            Serializer<T>.Serialize(stream, value);
        }
    }
