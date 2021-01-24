    public enum Mode { None, Break, Continue };
    public sealed class Branch<T>
    {
        public Mode Mode { get; }
        public T Value { get; }
        public Action Action { get; }
        public Branch(T value, Action action, Mode mode = Mode.None)
        {
            Value = value;
            Action = action;
            Mode = mode;
        }
    }
    public static class CaseHelper
    {
        public static void Switch<T>(T condition, params Branch<T>[] branches)
        {
            bool Continue = false;
            foreach (var branch in branches)
            {
                if (branch.Value.Equals(condition) || Continue)
                {
                    branch.Action();
                }
                if (branch.Mode == Mode.Break) break;
                Continue = branch.Mode == Mode.Continue;
            }
        }
    }
