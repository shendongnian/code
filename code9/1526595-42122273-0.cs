    class Program {
            static void Main(string[] args) {
                List<BaseClass> bigList = new List<BaseClass>();
                foreach (var type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()) {
                    if (typeof(BaseClass).IsAssignableFrom(type) && !(type.IsAbstract)) {
                        var ctor = type.GetConstructor(Type.EmptyTypes);
                        if (ctor != null) {
                            var countAttr = Attribute.GetCustomAttribute(type, typeof(InstantiationCountAttribute)) as InstantiationCountAttribute;
                            if (countAttr != null) {
                                for (int i = 0; i < countAttr.Count; ++i) {
                                    bigList.Add((BaseClass)ctor.Invoke(null));
                                }
                            }
                        }
                    }
                }
                foreach (var test in bigList) {
                    Console.WriteLine(test.GetType().Name);
                }
            }        
        }
        abstract class BaseClass {
        }
        class InstantiationCountAttribute : Attribute {
            public InstantiationCountAttribute(int count) {
                Count = count;
            }
            public int Count { get; private set; }
        }
    
        [InstantiationCount(1)]
        class A : BaseClass {
        }
    
        [InstantiationCount(34)]
        class B : BaseClass {
        }
