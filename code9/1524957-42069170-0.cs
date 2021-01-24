    public sealed class MeTransformEventArgs
        : MeEventArgs
    {
        public bool SuccesfullyTransformed { get; set; }
        public Vector3 PreviousPosition { get; set; }
        public Vector3 NewPosition { get; set; }
    }
