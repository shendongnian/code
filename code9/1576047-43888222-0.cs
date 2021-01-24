    public class SelectedMonkeyEventArgs : EventArgs
    {
        public SelectedMonkeyEventArgs(Monkey  monkey)
        {
            Monkey = monkey;
        }
        public Monkey Monkey { get; }
    }
