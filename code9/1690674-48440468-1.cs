    //Define type
    public enum ReturnType {
        HR,
        Dev,
        Finance
    }
    //Define methods
    public void HRMethod() { Console.WriteLine("HR"); }
    public void DevMethod() { Console.WriteLine("Dev"); }
    public void FinanceMethod() { Console.WriteLine("Finance"); }
    //Create a dictionary, where You add particular method for particular type
    Dictionary<ReturnType, Action> myDict = new Dictionary<ReturnType, Action>();
    myDict.Add(ReturnType.HR, HRMethod);
    myDict.Add(ReturnType.Dev, DevMethod);
    myDict.Add(ReturnType.Finance, FinanceMethod);
    
    //Whenever the call occurs
    myDict[ReturnType.HR].Invoke();	
    > HR
