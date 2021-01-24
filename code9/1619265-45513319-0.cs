    [TestInitialize]
    public Setup()
    {
         Dictionary<string, string> variables = new Dictionary<string, string>();
         //pseudocode
         if VariablesContainLetters
           variables.Add("var1", "a");
           variables.Add("var2", "b");
         else if VariablesContainNumbers
           variables.Add("var4", "1");
           variables.Add("var5", "2");
    }
    
    [TestMethod]
    [VariablesContainLetters]
    public method1() {MessageBox.Show(variable["var1"]);} //prints "a"
    
    [TestMethod]
    [VariablesContainNumbers]
    public method2() {MessageBox.Show(variable["var4"]);} //prints "1"
