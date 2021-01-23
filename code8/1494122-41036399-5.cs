        public abstract class Factory
        {
            private Factory()
            {
            }
            public abstract AbstractAI CreateInstance();
            public class Implementation<T> : Factory where T : AbstractAI, new()
            {
                
                public override AbstractAI CreateInstance()
                {
                    return new T();
                }
            }
        }
