    public class Class
    {
        [CompilerGenerated]
        private sealed class <>c__DisplayClass0_0
        {
            public string holder;
            internal void <Caller>b__0(string s)
            {
                this.holder = s;
            }
            internal void <Caller>g__SetHolder1(string s)
            {
                this.holder = s;
            }
        }
        public void Caller()
        {
            Class.<>c__DisplayClass0_0 @object = new Class.<>c__DisplayClass0_0();
            Action<string> setHolder = new Action<string>(@object.<Caller>b__0);
            this.DoStuff(setHolder);
            this.DoStuff(new Action<string>(@object.<Caller>g__SetHolder1));
        }
        public void DoStuff(Action<string> setHolder)
        {
            setHolder("holders new string");
        }
    }
