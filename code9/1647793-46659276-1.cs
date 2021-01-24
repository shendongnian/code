    public class DoStuff
    {
        public DoStuff()
        {
            var actionManager = new ActionManager();
            var a = 1;
            var b = 2;
            actionManager["action"].Invoke(a, b);
            //you can even Register New Action Like this :
            actionManager.Add("Multiply",(x,y)=>x*y);
            //then you can use it somewhere else:
            actionManager["Multiply"].Invoke(a, b);
        }
    }
