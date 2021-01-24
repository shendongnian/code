    internal class InspectorAspect : IMessageSink
        {
            internal InspectorAspect(IMessageSink next)
            {
                NextSink = next;
            }
    
            public IMessageSink NextSink { get; }
    
            public IMessage SyncProcessMessage(IMessage msg)
            {
                if (!(msg is IMethodMessage)) return NextSink.SyncProcessMessage(msg);
    
                var call = (IMethodMessage) msg;
                var type = Type.GetType(call.TypeName);
                if (type == null) return NextSink.SyncProcessMessage(msg);
    
                var methodInfo = type.GetMethod(call.MethodName);
                if (!Attribute.IsDefined(methodInfo, typeof (InspectableProperty)))
                    return NextSink.SyncProcessMessage(msg);
                Console.WriteLine($"Entering method: {call.MethodName}. Args being:");
                foreach (var arg in call.Args)
                    Console.WriteLine(arg);
                var returnMethod = NextSink.SyncProcessMessage(msg) as IMethodReturnMessage;
    
                Console.WriteLine($"Method {call.MethodName} returned: {returnMethod?.ReturnValue}");
                Console.WriteLine();
                return returnMethod;
            }
    
            public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
            {
                throw new InvalidOperationException();
            }
        }
