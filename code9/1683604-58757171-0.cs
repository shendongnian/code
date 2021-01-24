    using Mono.Cecil;
    using Mono.Cecil.Cil;
    using Mono.Cecil.Rocks;
    using System; 
    using System.Linq;
    using BindingFlags = System.Reflection.BindingFlags;
    using Cecilifier.Runtime;
                
    public class SnippetRunner
    {
        public static void Main(string[] args)
        {
            var assembly = AssemblyDefinition.CreateAssembly(new AssemblyNameDefinition("name", Version.Parse("1.0.0.0")), "moduleName", ModuleKind.Dll);
            var t1 = new TypeDefinition("", "Foo", TypeAttributes.AnsiClass | TypeAttributes.BeforeFieldInit | TypeAttributes.NotPublic, assembly.MainModule.TypeSystem.Object);
            assembly.MainModule.Types.Add(t1);
            t1.BaseType = assembly.MainModule.TypeSystem.Object;
            var Foo_ctor_ = new MethodDefinition(".ctor", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.RTSpecialName | MethodAttributes.SpecialName, assembly.MainModule.TypeSystem.Void);
            t1.Methods.Add(Foo_ctor_);
            var il1 = Foo_ctor_.Body.GetILProcessor();
            var Ldarg_02 = il1.Create(OpCodes.Ldarg_0);
            il1.Append(Ldarg_02);
            var Call3 = il1.Create(OpCodes.Call, assembly.MainModule.ImportReference(TypeHelpers.DefaultCtorFor(t1.BaseType)));
            il1.Append(Call3);
            var Ret4 = il1.Create(OpCodes.Ret);
            il1.Append(Ret4);
            
            var Foo_F_int32 = new MethodDefinition("F", MethodAttributes.Private | MethodAttributes.HideBySig, assembly.MainModule.TypeSystem.Void);
            t1.Methods.Add(Foo_F_int32);
            var il_Foo_F_int32 = Foo_F_int32.Body.GetILProcessor();
            var x5 = new ParameterDefinition("x", ParameterAttributes.None, assembly.MainModule.TypeSystem.Int32);
            Foo_F_int32.Parameters.Add(x5);
            // if (x < 10)
            var Ldarg_16 = il_Foo_F_int32.Create(OpCodes.Ldarg_1);
            il_Foo_F_int32.Append(Ldarg_16);
            var Ldc_I47 = il_Foo_F_int32.Create(OpCodes.Ldc_I4, 10);
            il_Foo_F_int32.Append(Ldc_I47);
            il_Foo_F_int32.Append(il_Foo_F_int32.Create(OpCodes.Clt));
            var esp8 = il_Foo_F_int32.Create(OpCodes.Nop);
            il_Foo_F_int32.Append(il_Foo_F_int32.Create(OpCodes.Brfalse, esp8));
            //if body
            
    // x = x + 1;
            var Ldarg_19 = il_Foo_F_int32.Create(OpCodes.Ldarg_1);
            il_Foo_F_int32.Append(Ldarg_19);
            var Ldc_I410 = il_Foo_F_int32.Create(OpCodes.Ldc_I4, 1);
            il_Foo_F_int32.Append(Ldc_I410);
            il_Foo_F_int32.Append(il_Foo_F_int32.Create(OpCodes.Add));
            var Starg_S11 = il_Foo_F_int32.Create(OpCodes.Starg_S, x5);
            il_Foo_F_int32.Append(Starg_S11);
            var ese12 = il_Foo_F_int32.Create(OpCodes.Nop);
            il_Foo_F_int32.Append(esp8);
            il_Foo_F_int32.Append(ese12);
            Foo_F_int32.Body.OptimizeMacros();
            var Ret13 = il_Foo_F_int32.Create(OpCodes.Ret);
            il_Foo_F_int32.Append(Ret13);
            assembly.Write(args[0]);
        }
    }
