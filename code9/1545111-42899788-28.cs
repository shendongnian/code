    public sealed class MyWindowPackage : Package
    {
        public const string PackageGuidString = "00000000-0000-0000-0000-000000000003";
        public MyWindowPackage() { }
        protected override void Initialize()
        {
            MyToolWindowCommand.Initialize(this);
            MySaveCommand.Initialize(this);
            base.Initialize();
        }
    }
