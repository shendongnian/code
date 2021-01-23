    using System;
    namespace KMAP
    {
        class CelestialBodyData
        {
            public string name { get; protected set; }
            public double radius { get; protected set; }
            public double mass { get; protected set; }
            public CelestialBodyData(string name, double radius, double mass)
            {
                this.name = name;
                this.radius = radius;
                this.mass = mass;
            }
        }
    }
