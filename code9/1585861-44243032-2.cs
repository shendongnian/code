    public class AnimationStep
    {
        public Bitmap Bitmap { get; set; }
        // the y-offset
        public int OffsetY { get; set; }
        // indicates whether this was the last step of the animation
        public bool Completed { get; set; }
        // a jump animation can be interrupted by a jetpack animation, but a DieAnimation cant:
        public bool CanBeInterrupted { get; set; }
        ...
    }
