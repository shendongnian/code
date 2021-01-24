    public class DoStuff
    {
        public DoStuff()
        {
            var actionManager = new ActionManager();
            var a = 1;
            var b = 2;
            //var actionResult= actionManager[this should come from your drop down].Invoke(a, b);
            var actionResult= actionManager["action"].Invoke(a, b);
            //you can even Register New Action Like this :
            actionManager.Add("Multiply",(x,y)=>x*y);
            //then you can use it somewhere else:
            var multiplyResult =  actionManager["Multiply"].Invoke(a, b);
        }
    }
