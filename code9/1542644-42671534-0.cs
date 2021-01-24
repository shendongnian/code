    public static class CaseHelper 
    {
        public enum Mode {None, Break, Continue};
        public sealed class Branch
        {
            Mode Mode {get; }
            T Value {get; }
            Action Action {get; }
        
            public Branch(T value, Action action, Mode = Mode.None)
            {
                Value = value;
                Action = action;
                Mode = mode;
            }    
        }
        public static void Switch<T>(T condition, params Branch[] branches)
        {
            bool Continue = false; 
            foreach (var branch in branches)
            {
               if (branch.Equals(condition) || Continue)
               {
                  branch.Action();
               }
               
               if (branch.Mode == Mode.Break) break;
               Continue = branch.Mode == Mode.Continue;
            } 
        }
    }
