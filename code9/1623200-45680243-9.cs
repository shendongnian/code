    using System;
    
    struct Vector3
    {
        public float x, y, z;
        
        public override string ToString() => $"x={x}; y={y}; z={z}";
    }
    
    static class Extensions
    {
        public static void DoubleComponents(this Vector3 v)
        {
            v.x *= 2;
            v.y *= 2;
            v.z *= 2;
        }
        public static void DoubleComponentsByRef(ref Vector3 v)
        {
            v.x *= 2;
            v.y *= 2;
            v.z *= 2;
        }
    }
    
    class Test
    {
        static void Main()
        {
            Vector3 vec = new Vector3 { x = 10, y = 20, z = 30 };
            Console.WriteLine(vec); // x=10; y=20; z=30
            vec.DoubleComponents();
            Console.WriteLine(vec); // Still x=10; y=20; z=30
            Extensions.DoubleComponentsByRef(ref vec);
            Console.WriteLine(vec); // x=20; y=40; z=60
        }
    }
