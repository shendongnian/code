    public class FuncModel
    {
        //Func syntax goes <input1, input2,...., output>
        public Func<string, string, string> FunctTest { get; set; }
    }
    var funcModel = new FuncModel();
    funcModel.FunctTest = (firstName, lastName) => firstName + lastName;
    Console.WriteLine(funcModel.FuncTest("John", "Smith"));
