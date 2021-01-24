    static class Program
    {
        internal static void Main(string[] args)
        {
            int[] intCoefficients = new int[] { 5, 15, 2, 10, 3, 7 };
            Polynomial firstpolynomial = new Polynomial(5);
            Polynomial secondpolynomial = new Polynomial( intCoefficients );
            Polynomial polynomialthree;
            polynomialthree=firstpolynomial+secondpolynomial;
            Console.WriteLine("Polynomial Equation");
            Console.WriteLine();
            //call the method
            secondpolynomial.Display();
            firstpolynomial.Display();
            polynomialthree.Display();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
    public class Polynomial : IComparable, IComparable<Polynomial>
    {
        readonly int[] intCoefficient;
        //constructors
        public Polynomial() //this constructor creates the polynomial 0
            : this(0) { }
        public Polynomial(int intDegree) //creates x^5 polynomial
        {
            this.intCoefficient=new int[intDegree+1];
            this.intCoefficient[intDegree]=1;
        }
        public Polynomial(params int[] intArray) //creates other polynomial
        {
            this.intCoefficient=intArray;
        }
        //properties
        public int Degree
        {
            get
            {
                return intCoefficient.Length-1;
            }
        }
        public int[] Coefficient
        {
            get
            {
                return intCoefficient;
            }
        }
        /// <summary>
        /// Converts the polynomial to a string representation
        /// </summary>
        /// <returns>A string object</returns>
        public override string ToString() 
        {
            StringBuilder result = new StringBuilder();
            for (int i=0; i<=Degree; i++)
            {
                int coef = intCoefficient[i];
                int sign = Math.Sign(coef);
                coef=Math.Abs(coef);
                if (coef>0)
                {
                    if (sign<0)
                    {
                        // always add a leading negative when needed
                        result.Append("-");
                    }
                    else if (result.Length>0)
                    {
                        // only add a leading plus if not first term
                        result.Append("+");
                    }
                    // append Cx^i terms
                    if (coef>1&&i>1)
                    {
                        result.AppendFormat("{0}x^{1}", coef, i);
                    }
                    else if (coef>1&&i==1)
                    {
                        result.AppendFormat("{0}x", coef);
                    }
                    else if (coef>1&&i==0)
                    {
                        result.AppendFormat("{0}", coef);
                    }
                    else if (coef==1&&i==1)
                    {
                        result.Append("x");
                    }
                    else if (i==0)
                    {
                        result.Append(coef.ToString());
                    }
                    else
                    {
                        result.AppendFormat("x^{0}", i);
                    }
                } // ignore term of coef==0
            }            
            return result.ToString();
        }
        /// <summary>
        /// Adds the coefficients of two polynomials
        /// </summary>
        /// <param name="firstpolynomial">A polynomial</param>
        /// <param name="secondpolynomial">Another polynomial</param>
        /// <returns>The resulting polynomial</returns>
        public static Polynomial operator +(Polynomial firstpolynomial, Polynomial secondpolynomial)
        {
            // Always make sure the first polynomial has equal or more terms
            if (secondpolynomial.Degree>firstpolynomial.Degree)
            {
                // Reverse the operation
                return secondpolynomial+firstpolynomial;
            }
            // Result must have same degree as first poly
            int result_degree = firstpolynomial.Degree;
            int[] result_coef = new int[result_degree+1];
            for (int i = 0; i<secondpolynomial.intCoefficient.Length; i++)
            {
                // Add coefficients from two polynomials
                result_coef[i]=firstpolynomial.intCoefficient[i]+secondpolynomial.intCoefficient[i];
            }
            for (int i = secondpolynomial.intCoefficient.Length; i<result_coef.Length; i++)
            {
                // Assign remaining coefficients from fist polynomial
                result_coef[i]=firstpolynomial.intCoefficient[i];
            }
            return new Polynomial(result_coef);
        }
        //display method
        public void Display() 
        {
            Console.WriteLine(ToString());
        }
        public int CompareTo(Polynomial other)
        {
            // Just compare the order of the polynmomials
            return Degree.CompareTo(other.Degree);
        }
        int IComparable.CompareTo(Object o)
        {
            if (o is Polynomial)
            {
                return CompareTo(o as Polynomial);
            }
            return 0;
        }
    }
