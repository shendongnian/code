c#
public class LoadConcreteFamily : LoadFamily
{
    public LoadConcreteFamily(RevitFamily f) : base(f)
    { }
}
accordingly your type definition will include the new argument and the signature is clearly different from what you ask, but the code is self contained and does not use a global context.
***2nd approach*** Have a global instance holding your data:
c#
public static class FamilyContainer
{
    public static RevitFamily SharedFamily { get; private set; }
    public static void InitializeFamily(RevitFamily family)
    {
        if (family == null)
            throw new ArgumentNullException(nameof(family));
        SharedFamily = family;
    }
}
public class LoadConcreteFamily : LoadFamily
{
    public LoadConcreteFamily() : base(FamilyContainer.SharedFamily)
    {
    }
}
which should be (untested):
c#
TypeBuilder tb = mb.DefineType(newTypeName, new TypeAttributes(), typeof(LoadFamily));
var ci = typeof(LoadFamily).GetConstructor(new[] { typeof(RevitFamily) });
var constructorBuilder = tb.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, new Type[0]);
var gen = constructorBuilder.GetILGenerator();
gen.DeclareLocal(typeof(RevitFamily));
gen.Emit(OpCodes.Ldarg_0);
gen.Emit(OpCodes.Call, typeof(FamilyContainer).GetProperty(nameof(FamilyContainer.SharedFamily), BindingFlags.Public | BindingFlags.Static).GetGetMethod());
gen.Emit(OpCodes.Call, ci);
gen.Emit(OpCodes.Ret);
t = tb.CreateType();
IMHO, The introduction of a static instance should be carefully evaluated as global variables introduce unintended and unforseenable dependencies to your code making it more complex to be maintained and debugged.
You might benefit reading this SO question [Are global variables bad?][20] even if not C# specific.
For this reason, I would go with the first approach.
<sup>[1]</sup> there are several details that I omitted for brevity, and probably the oversimplification could be more difficult of the concept itself
[10]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/constructors
[20]: https://stackoverflow.com/questions/484635/are-global-variables-bad
