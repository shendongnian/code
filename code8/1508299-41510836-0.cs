    using System;
    using System.Threading.Tasks;
    using PostSharp.Aspects;
    using PostSharp.Serialization;
    namespace OnMethodBoundaryAsyncTest
    {
        interface IDirtiness
        {
            bool Dirty { get; set; }
        }
        class MyClassWithSomeDirtyObjects : IDirtiness
        {
            public bool Dirty { get; set; }
        }
        [PSerializable]
        class ReportDirtinessAttribute : OnMethodBoundaryAspect
        {
            public override void OnSuccess( MethodExecutionArgs args )
            {
                IDirtiness maybeDirtyObject = args.ReturnValue as IDirtiness;
                if ( maybeDirtyObject != null )
                {
                    string dirty = maybeDirtyObject.Dirty ? "is" : "is not";
                    Console.WriteLine($"{maybeDirtyObject} {dirty} dirty.");
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                CreateObject( false ).GetAwaiter().GetResult();
                CreateObject( true ).GetAwaiter().GetResult();
            }
            [ReportDirtiness(ApplyToStateMachine = true)]
            static async Task<MyClassWithSomeDirtyObjects> CreateObject( bool dirty )
            {
                return new MyClassWithSomeDirtyObjects {Dirty = dirty};
            }
        }
    }
