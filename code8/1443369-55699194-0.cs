        public static void TickAll()
        {
            // This will loop through all CognateBase objects and call their Tick, or if deleted from memory, remove the CognateBase.
            AllCognateBases.RemoveAll(_TickIfAble);
        }
