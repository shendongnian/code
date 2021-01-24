    //Define methods
    public IEnumerable<HR> GetHR() { return new List<HR>() {new HR() {Name="HR" } }; }
    public IEnumerable<Dev> GetDev() { return new List<Dev>() {new Dev() {Name="Dev" } }; }
    //Create dict + fill
    Dictionary<ReturnType, Func<object>> myDict2 = new Dictionary<ReturnType, Func<object>>();
    myDict2.Add(ReturnType.HR, GetHR);
    myDict2.Add(ReturnType.Dev, GetDev);
    //Work with it as with result type
    var lRes = (myDict2[ReturnType.HR].Invoke() as IEnumerable<HR>);
    Console.WriteLine(lRes.First().Name);
    > HR
