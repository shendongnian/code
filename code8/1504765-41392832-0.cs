        public class BaseObject<T> where T : RuntimeApiManagerBase
        {
            public BaseObject(T runtimeApiMgr)
            {
                RuntimeApiMgr = runtimeApiMgr;
            }
            public T RuntimeApiMgr { get; set; }
        }
        public class Catalog : BaseObject<CatalogRuntimeApiManagerBase>
        {
            public Catalog() : base(new CatalogRuntimeApiManagerBase())
            {
            }
        }
        public class Document : BaseObject<DocumentRuntimeApiManagerBase>
        {
            public Document() : base(new DocumentRuntimeApiManagerBase())
            {
            }
        }
        Catalog c1 = new Catalog();
        c1.RuntimeApiMgr.Method1();
        Document d1 = new Document();
        d1.RuntimeApiMgr.Method2();
