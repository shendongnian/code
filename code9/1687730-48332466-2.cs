    public interface IGravitySource
    {
        IGravity Gravity { get; }
    }
    internal interface IGravity
    {
        double AccelerationDueToGravity { get; }
    }
    public sealed class Foo : IGravitySource
    {
        private readonly Physics myPrivatePhysics = new Physics();
        private sealed class Physics : IGravity
        {
            public double AccelerationDueToGravity { get; } = 9.81;
            public double Smoothness { get; } = 0.05;
        }
        public IGravity Gravity => myPrivatePhysics;
    }
    public sealed class Bar
    {
        private readonly IGravitySource gravitySource;
        public Bar(IGravitySource gravitySource)
        {
            this.gravitySource = gravitySource;
        }
        public void Start()
        {
            //...
            var gravity = gravitySource.Gravity.AccelerationDueToGravity;
            gravity += 1;
            //...
        }
    }
