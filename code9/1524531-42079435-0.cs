    static void Main(string[] args)
    {
        var dynamicAdd2 = new DynamicMethod("add",
                typeof(string),
                new[] { typeof(Program), typeof(TestType) },
                typeof(Program).Module,
                false);
        var ilGenerator = dynamicAdd2.GetILGenerator();
        ilGenerator.DeclareLocal(typeof(string));
        ilGenerator.Emit(OpCodes.Ldarg_1);
        var fld = typeof(TestType).GetField("Name");
        ilGenerator.Emit(OpCodes.Ldfld, fld);
        ilGenerator.Emit(OpCodes.Ret);
        var test2 = (Func<TestType, string>)dynamicAdd2.CreateDelegate(typeof(Func<TestType, string>), new Program());
        var ret2 = test2(new TestType());
    }
