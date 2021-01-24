    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EqualsFunc = System.Func<int, int, bool>;
    using PostFilter = Func<System.Collections.Generic.KeyValuePair<string, PostMeta>, bool>; 
    using MyPair = System.Collections.Generic.KeyValuePair<string,int>;
    namespace TypeAlias
    {
        class Program
        {
            static void Main(string[] args)
            {
                EqualsFunc equals = (a, b) => a == b;
                var result == equals(1, 2); //false
                PostFilter filter = x =>
                x.Value.Category == pageMeta.Value.Category && x.Key != pageMeta.Key;
                var filterResult = filter(new MyPair("key",5),10); 
            }
        }
    }
