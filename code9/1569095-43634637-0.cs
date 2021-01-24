    IEnumerable<MethodInfo> methods = 
               Enumerable.Range(1, 100)
                         .Select(i => $"CCU_O.MWT.DRSa09_DrEmrgOpn.DRSa09_DrEmrgOpnCst.DCU{i:D2}_IEmergOpenAct")
                         .Select(t => Type.GetType(t))
                         .Select(t => t.GetMethod("Force", BindingFlags.Public | BindingFlags.Static));
    foreach (MethodInfo force in methods)
         force.Invoke(null, new object[] { false });
