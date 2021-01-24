        public static void Attach<T>(EventHandler<T> a, EventHandler<T> b)
        {
            a += b;
        }
        public static void Detach<T>(EventHandler<T> a, EventHandler<T> b)
        {
            a -= b;
        }
        public static void AttachDetachHandlers<T>(Action<EventHandler<T>, EventHandler<T>> op)
        {
            op(event1, handler1);
            op(event2, handler2);
            //etc...
        }
