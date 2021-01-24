    using System;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                double m11 = 0.00000001, // 1E-08
                    m12 = 0,
                    m21 = 0,
                    m22 = 0.0000001; // 1E-07        
                double det = m11 * m22 - m12 * m21;
                Console.WriteLine(det);
                var mat = new System.Windows.Media.Matrix(m11, m12, m21, m22, 0, 0);
                Console.WriteLine(mat.Determinant);
                if (mat.Determinant == det)
                    Console.WriteLine("Same results!"); // This is printed.
                Console.WriteLine(mat.HasInverse); // Has no inverse, though.
            }
        }
    }
