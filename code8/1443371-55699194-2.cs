            public static void UnitTest()
        {
            Debug.Assert(AllCognateBases.Count == 0);
            CognateBase b1 = new CognateBase();
            Debug.Assert(AllCognateBases.Count == 1);
            CognateBase b2 = new CognateBase();
            Debug.Assert(AllCognateBases.Count == 2);
            GC.Collect();
            Debug.Assert(AllCognateBases.Count == 2);
            b1 = null;
            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.WaitForPendingFinalizers();
            TickAll();
            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.WaitForPendingFinalizers();
            Debug.Assert(AllCognateBases.Count == 1);
            b2 = null;
            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.WaitForPendingFinalizers();
            TickAll();
            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.WaitForPendingFinalizers();
            Debug.Assert(AllCognateBases.Count == 0);
        }
