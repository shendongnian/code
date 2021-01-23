    // betterscript.csx:
    public class ScriptWork : IHaveWork
    {
        Work(HeavyType obj)
        {
            obj.DoSomeWork();
        }
    }
    return new ScriptWork();
