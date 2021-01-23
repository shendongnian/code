    using System.Reflection;
    using System.Linq;
    [Return()]
    void MyMethod(int x)
    {
        var skip = MethodBase.GetCurrentMethod().GetCustomAttributes( typeof( ReturnAttribute ), false ).Any();
        if (skip) return;
        //Rest of the code goes here
    }
