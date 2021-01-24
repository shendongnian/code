    public sealed class MeRotationEventArgs
        : MeEventArgs
    {
        public bool Successfull { get; set; }
        public Quaternion FromAngle { get; set; }
        public Quaternion ToAngle { get; set; }
    }
