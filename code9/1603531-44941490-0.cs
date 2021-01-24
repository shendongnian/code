        static RequestHandler()
        {
            var assembly = typeof(RequestHandler).GetTypeInfo().Assembly;
            foreach (var t in assembly.GetTypes())
            {
                if (t.GetInterfaces().Contains(typeof(IIntent)))
                {
                    Intents.Add(Activator.CreateInstance(t) as IIntent);
                }
            }
        }
