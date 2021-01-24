    public class Version: IVersion
    {
        public int Major { get; }
        public int Minor { get; }
        public int Build { get; }
        
        public override string ToString =>
            $”{Major}.{Minor}.{Build}” 
        public Version(int major, int minor, int build)
        {
            //omitted argument validation
            Major = major;
            Minor = minor;
            Build = build;
        }
    }
