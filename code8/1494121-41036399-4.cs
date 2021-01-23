        private static readonly Dictionary<String, Factory> aiMap = new Dictionary<string, Factory>();
        public static void Add<T>(string name) where T : AbstractAI, new()
        {
            aiMap.Add(name, new Factory.Implementation<T>());
        }
        public static AI2 SetupAI(String name, Creature owner)
        {
            AbstractAI aiInstance = null;
            try
            {
                aiInstance = aiMap[name].CreateInstance();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("[AI2] AI factory error: " + name, e);
            }
            return aiInstance;
        }
