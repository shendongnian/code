    void Main()
    {
        var assembly = AssemblyDefinition.ReadAssembly(GetType().Assembly.Location);
        var myClassType =
            (from module in assembly.Modules
             from type in module.Types
             where type.Name == "UserQuery"
             from nestedType in type.NestedTypes
             where nestedType.Name == "MyClass"
             select nestedType).FirstOrDefault();
         
        var ctor =
            (from method in myClassType.Methods
             where method.IsConstructor
             select method).FirstOrDefault();
             
        foreach (var instruction in ctor.Body.Instructions)
            Console.WriteLine(instruction.ToString());
    }
    
    public class MyClass
    {
        public int Id { get; set; } = 5;
    }
