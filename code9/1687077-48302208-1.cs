    var dm = new DynamicMethod(nameof(double.CompareTo), typeof(int),
         new[] { typeof(double), typeof(double) });
    var il = dm.GetILGenerator();
    il.Emit(OpCodes.Ldarga_S, 0);  // load "ref arg0"
    il.Emit(OpCodes.Ldarg_1);      // load "arg1"
    il.Emit(OpCodes.Call, method); // call CompareTo
    il.Emit(OpCodes.Ret);
    var func = (Func<double, double, int>)dm.CreateDelegate(
         typeof(Func<double, double, int>));
