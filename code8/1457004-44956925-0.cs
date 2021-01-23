    static class SystemMap {
        // Store some mapping information in a commonly accessible system resource
        // In this case a simple static class that wraps up a dictionary
        static Dictionary<Type, Master> systemMap = new Dictionary<Type, Master>();
        // Allow registered components to be accessed
        public static Master getRegisteredMaster(Type handlerType) {
            return systemMap[handlerType];
        }
        // Allow new registrations to be made in your system
        public static void registerNewMaster(Master registrant, Type handlerType) {
            systemMap[handlerType] = registrant;
        }
    }
    class Master {
        // This would be your custom class that you instantiate throughout your system
        public string name;
        public int someVar { get; set; } = new Random().Next(1, 100);
        public Master(string name) {
            this.name = name;
        }
    }
    class BaseHandlerType {
        // This would be NSURLProtocol
    }
    class Handler1 : BaseHandlerType {
        // This would be canInitWithRequest
        public static bool CanCreate(int someVar) {
            Master myMaster = SystemMap.getRegisteredMaster(typeof(Handler1));
            return someVar > myMaster.someVar;
        }
    }
    class Handler2 : BaseHandlerType {
        //... Register various handler types to various "Master" instances in your system
        // This is a concrete implementation of NSURLProtocol
    }
    class Handler3 : BaseHandlerType {
        //... Register various handler types to various "Master" instances in your system
        // This is a concrete implementation of NSURLProtocol
    }
    class SystemFactory {
        // Use a factory method to instantiate the system components and plug things together
        public void initializeSystem() {
            var masterA = new Master("a");
            var masterB = new Master("b");
            var masterC = new Master("c");
            SystemMap.registerNewMaster(masterA, typeof(Handler1));
            SystemMap.registerNewMaster(masterB, typeof(Handler2));
            SystemMap.registerNewMaster(masterC, typeof(Handler3));
            SomeLibrary.register(typeof(Handler1));
            SomeLibrary.register(typeof(Handler2));
            SomeLibrary.register(typeof(Handler3));
        }
    }
    static class SomeLibrary {
        public static void register(Type handlerType) {
            // This represents the API registration
        }
    }
