     public class ActionManager : Dictionary<string, Func<int, int, int>>
        {
            public ActionManager()
            {
                this.Add("action", (x, y) => x + y);
                this.Add("Subtract", (x, y) => x - y);
            }
    
        }
