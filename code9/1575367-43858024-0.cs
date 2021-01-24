        public static class Utility
        {
            public static dynamic AsDynamic(this NameValueCollection collection)
            {
                return (NameValueCollectionDynamicAdapter)collection;
            }
            private class NameValueCollectionDynamicAdapter : DynamicObject
            {
                private NameValueCollection collection;
                public NameValueCollectionDynamicAdapter(NameValueCollection collection)
                {
                    this.collection = collection ?? throw new NullReferenceException(nameof(collection));
                }
                public override bool TryGetMember(GetMemberBinder binder, out object result)
                {
                    result = collection[binder.Name];
                    return true;
                }
                public override bool TrySetMember(SetMemberBinder binder, object value)
                {
                    collection[binder.Name] = value?.ToString();
                    return true;
                }
                public static implicit operator NameValueCollection(NameValueCollectionDynamicAdapter target)
                {
                    return target.collection;
                }
                public static explicit operator NameValueCollectionDynamicAdapter(NameValueCollection collection)
                {
                    return new NameValueCollectionDynamicAdapter(collection);
                }
            }
        }
