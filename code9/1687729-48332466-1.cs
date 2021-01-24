    public interface IGravitySource
    {
        double Gravity { get; }
    }
    public sealed class Foo : IGravitySource
    {
        private readonly Physics myPrivatePhysics = new Physics();
        private sealed class Physics
        {
            public double Gravity { get; } = 9.81;
            public double Smoothness { get; } = 0.05;
        }
        public double Gravity => myPrivatePhysics.Gravity;
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
            var gravity = gravitySource.Gravity;
            gravity += 1;
            //...
        }
    }
