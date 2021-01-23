        [ComVisible(false)]
        public static String Concat(IEnumerable<String> values) {
            if (values == null)
                throw new ArgumentNullException("values");
            Contract.Ensures(Contract.Result<String>() != null);
            Contract.EndContractBlock();
 
            StringBuilder result = StringBuilderCache.Acquire();
            using(IEnumerator<String> en = values.GetEnumerator()) {
                while (en.MoveNext()) {
                    if (en.Current != null) {
                        result.Append(en.Current);
                    }
                }            
            }
            return StringBuilderCache.GetStringAndRelease(result);            
        }
