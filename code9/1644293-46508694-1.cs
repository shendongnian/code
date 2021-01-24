    using static System.Math;
    using PointF =  System.Drawing.PointF;
    public struct Vector2 : IEquatable<Vector2>
    {
        public Vector2(double x, double y) { this.X=x; this.Y=y; }
        public static readonly Vector2 Zero = new Vector2(0, 0);
        public static readonly Vector2 UnitX = new Vector2(1, 0);
        public static readonly Vector2 UnitY = new Vector2(0, 1);
        public double Magnitude => Math.Sqrt(X*X+Y*Y);
        public Vector2 Direction => Normalized();
        public double X { get; }
        public double Y { get; }
        public bool IsZero => X*X+Y*Y==0;
        public Vector2 Normalized() => Magnitude>0 ? this/Magnitude : Zero;
        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X+b.X, a.Y+b.Y);
        }
        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X-b.X, a.Y-b.Y);
        }
        public static Vector2 operator *(double f, Vector2 a)
        {
            return new Vector2(f*a.X, f*a.Y);
        }
        public static Vector2 operator *(Vector2 a, double f) { return f*a; }
        public static Vector2 operator /(Vector2 a, double d) { return (1/d)*a; }
        public override bool Equals(object obj)
        {
            if (obj is Vector2)
            {
                return Equals((Vector2)obj);
            }
            return false;
        }
        public bool Equals(Vector2 other)
        {
            return X==other.X&&Y==other.Y;
        }
        public static bool operator ==(Vector2 u, Vector2 v)
        {
            return u.Equals(v);
        }
        public static bool operator !=(Vector2 u, Vector2 v)
        {
            return !(u==v);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hc = 17;
                hc=23*hc+X.GetHashCode();
                hc=23*hc+Y.GetHashCode();
                return hc;
            }
        }
    }
    public struct Point2
    {
        /// <summary>
        /// Define a point by three homogeneous coordinates
        /// </summary>
        public Point2(double u, double v, double w)
        {
            this.U=u;
            this.V=v;
            this.W=w;
        }
        /// <summary>
        /// Define a point from (x,y) coordinates
        /// </summary>
        public static Point2 FromCoordinates(double x, double y)
        {
            return new Point2(x, y, 1);
        }
        /// <summary>
        /// Define a point from vector coordinates
        /// </summary>
        public static Point2 FromCoordinates(Vector2 r)
        {
            return new Point2(r.X, r.Y, 1);
        }
        /// <summary>
        /// Get point along a direction, at a certain distance
        /// </summary>
        /// <param name="n">The direction</param>
        /// <param name="d">The distance</param>
        public static Point2 FromDirectionAndDistance(Vector2 n, double d)
        {
            n=n.Direction;
            return new Point2(d*n.X, d*n.Y, 1);
        }
        /// <summary>
        /// Define a point where two lines meet (intersection)
        /// </summary>
        public static Point2 FromTwoLiness(Line2 m, Line2 n) { return Geometry.Meet(m, n); }
        /// <summary>
        /// A point at the origin
        /// </summary>
        public static readonly Point2 Origin = new Point2(0, 0, 1);
        /// <summary>
        /// A point on the unit x-axis
        /// </summary>
        public static readonly Point2 OneX = new Point2(1, 0, 1);
        /// <summary>
        /// A point on the unit y-axis
        /// </summary>
        public static readonly Point2 OneY = new Point2(0, 1, 1);
        /// <summary>
        /// First point at the horizon (infinity)
        /// </summary>
        public static readonly Point2 I = new Point2(1, 0, 0);
        /// <summary>
        /// Second point at the horizon (infinity);
        /// </summary>
        public static readonly Point2 J = new Point2(0, 1, 0);
        public double U { get; }
        public double V { get; }
        public double W { get; }
        public Point2 Normalized() => FromCoordinates(Coordinates);
        public bool IsFinite => !IsInfinite;
        public bool IsInfinite => W==0;
        /// <summary>
        /// The (x,y) coordinates of the point
        /// </summary>
        public Vector2 Coordinates => new Vector2(U/W, V/W);
        /// <summary>
        /// The center is at the point
        /// </summary>
        public Point2 Center => this;
        /// <summary>
        /// The direction is from the origin to the point
        /// </summary>
        public Vector2 Direction => new Vector2(U, V).Direction;
        /// <summary>
        /// The distance to the origin
        /// </summary>
        public double Distance => Sqrt(U*U+V*V)/Magnitude;
        /// <summary>
        /// The magnitude is weight of the point
        /// </summary>
        public double Magnitude => W;
        /// <summary>
        /// Offset a point by a vector
        /// </summary>
        /// <param name="p">The point</param>
        /// <param name="e">The offset vector</param>
        /// <returns>A new point</returns>
        public static Point2 operator +(Point2 p, Vector2 e)
        {
            return new Point2(p.U+p.W*e.X, p.V+p.W*e.Y, p.W);
        }
        /// <summary>
        /// Get the offset between two points
        /// </summary>
        public static Vector2 operator -(Point2 p, Point2 q)
        {
            return p.Coordinates-q.Coordinates;
        }
        /// <summary>
        /// Inner product between point and line. This is proportional to the distance
        /// and hence it is zero when the point is on the line.
        /// </summary>
        public static double operator *(Point2 p, Line2 m)
        {
            return m.A*p.U+m.B*p.V+m.C*p.W;
        }
        /// <summary>
        /// Defines the point joint operator (cross product) between two points
        /// </summary>
        public static Line2 operator ^(Point2 p, Point2 q) { return Geometry.Join(p, q); }
        /// <summary>
        /// Conversion between Point2 and PointF
        /// </summary>
        public static implicit operator PointF(Point2 p)
        {
            return new PointF((float)(p.U/p.W), (float)(p.V/p.W));
        }
    }
    public struct Line2
    {
        /// <summary>
        /// Define a line by three coefficients (a,b,c) such that the 
        /// equation of the line is `a*x+b*y+c=0`
        /// </summary>
        public Line2(double a, double b, double c)
        {
            this.A=a;
            this.B=b;
            this.C=c;
        }
        /// <summary>
        /// Define a line joining two points
        /// </summary>
        public static Line2 FromTwoPoints(Point2 p, Point2 q) { return Geometry.Join(p, q); }
        /// <summary>
        /// Define a line along a directrion and through a point
        /// </summary>
        /// <param name="p">The point</param>
        /// <param name="e">The direction</param>
        public static Line2 ThroughPointAlongDirection(Point2 p, Vector2 e)
        {
            return new Line2(-p.W*e.Y, p.W*e.X, p.U*e.Y-p.V*e.X);
        }
        /// <summary>
        /// Define a line parallel to another line and through a point
        /// </summary>
        /// <param name="p">The point</param>
        /// <param name="m">The other line</param>
        /// <returns></returns>
        public static Line2 ThroughPointParallelToLine(Point2 p, Line2 m)
        {
            return new Line2(m.A*p.W, m.B*p.W, -m.A*p.U-m.B*p.V);
        }
        /// <summary>
        /// Define a line perpendicular to another line and through a point
        /// </summary>
        /// <param name="p">The point</param>
        /// <param name="m">The other line</param>
        /// <returns></returns>
        public static Line2 ThroughPointNormalToLine(Point2 p, Line2 m)
        {
            return new Line2(-m.B*p.W, m.A*p.W, m.B*p.U-m.A*p.V);
        }
        /// <summary>
        /// Define a line normal to a direction and a certain distance from the origin
        /// </summary>
        /// <param name="n">The normal vector</param>
        /// <param name="d">The distance. Positive & negative values are valid</param>
        public static Line2 FromNormalAndDistance(Vector2 n, double d)
        {
            return new Line2(n.X, n.Y, -d*n.Magnitude);
        }
        /// <summary>
        /// Define a line along a direction and a certain distance from the origin
        /// </summary>
        /// <param name="e">The direction vector</param>
        /// <param name="d">The distance. Positive & negative values are valid</param>
        public static Line2 FromDirectionAndDistance(Vector2 e, double d)
        {
            return new Line2(-e.Y, e.X, -d*e.Magnitude);
        }
        /// <summary>
        /// X-axis is the line defined by `y=0`
        /// </summary>
        public static readonly Line2 XAxis = new Line2(0, 1, 0);
        /// <summary>
        /// Y-axis is the line defined by `x=0`
        /// </summary>
        public static readonly Line2 YAxis = new Line2(1, 0, 0);
        /// <summary>
        /// The horizon is the unique line at infinity
        /// </summary>
        public static readonly Line2 Horizon = new Line2(0, 0, 1);
        public double A { get; }
        public double B { get; }
        public double C { get; }
        public Line2 Normalized() => FromNormalAndDistance(Normal, Distance);
        public bool IsFinite => !IsInfinite;
        public bool IsInfinite => A*A+B*B==0;
        /// <summary>
        /// The center of the line is the point on the line closest to the origin
        /// </summary>
        public Point2 Center => new Point2(-A*C, -B*C, A*A+B*B);
        /// <summary>
        /// The direction vector along the line
        /// </summary>
        public Vector2 Direction => new Vector2(-B, A).Direction;
        /// <summary>
        /// The normal vector to the line
        /// </summary>
        public Vector2 Normal => new Vector2(A, B).Direction;
        /// <summary>
        /// The closest distance of the line to the origin
        /// </summary>
        public double Distance => C/Magnitude;
        /// <summary>
        /// The magnitude of the line is norm of the [A,B] vector
        /// </summary>
        public double Magnitude => Sqrt(A*A+B*B);
        /// <summary>
        /// Offset a line by a vector. 
        /// </summary>
        /// <param name="a">The line</param>
        /// <param name="e">The offset vector</param>
        /// <returns>A parallel line</returns>
        public static Line2 operator +(Line2 a, Vector2 e)
        {
            return new Line2(a.A, a.B, a.C-a.A*e.X-a.B*e.Y);
        }
        /// <summary>
        /// Get the offset vector of two parallel lines
        /// </summary>
        public static Vector2 operator -(Line2 m, Line2 n)
        {
            return Geometry.IsParallel(m, n) ? m.Normal*Geometry.Distance(m, n) : Vector2.Zero;
        }
        /// <summary>
        /// Inner product between point and line. This is proportional to the distance
        /// and hence it is zero when the point is on the line.
        /// </summary>
        public static double operator *(Line2 m, Point2 p)
        {
            return m.A*p.U+m.B*p.V+m.C*p.W;
        }
        /// <summary>
        /// Defines the line meet operator (cross product) between two lines
        /// </summary>
        public static Point2 operator ^(Line2 m, Line2 n) { return Geometry.Meet(m, n); }
    }
    public static class Geometry
    {
        public static double Dot(Point2 p, Line2 m) { return p * m; }
        public static double Dot(Line2 m, Point2 p) { return m * p; }
        public static Point2 Cross(Line2 m, Line2 n) { return m ^ n; }
        public static Line2 Cross(Point2 p, Point2 q) { return p ^ q; }
        /// <summary>
        /// Check for parallelism between two lines. Due to roundoff errors
        /// this will return false when lines are almost parallel.
        /// </summary>
        public static bool IsParallel(Line2 m, Line2 n)
        {
            return m.A*n.B-m.B*n.A==0;
        }
        /// <summary>
        /// Check for coincidence between two points. Due to roundoff errors
        /// this will return false when two points are nearly coincident.
        /// </summary>
        public static bool IsCoincident(Point2 p, Point2 q)
        {
            return p.U*q.W-q.U*p.W==0
                &&p.V*q.W-q.V*p.V==0;
        }
        /// <summary>
        /// Check for parallelism and separation between two lines
        /// </summary>
        public static bool IsCoincident(Line2 m, Line2 n)
        {
            return IsParallel(m, n)&& Distance(m,n)==0;
        }
        /// <summary>
        /// Check if a line is passing through a point
        /// </summary>
        public static bool IsCoincident(Line2 m, Point2 p) => IsCoincident(p, m);
        /// <summary>
        /// Check if point lies on a line
        /// </summary>
        public static bool IsCoincident(Point2 p, Line2 m)
        {
            return p*m==0;
        }
        /// <summary>
        /// Check if two points are near each other within tolerance
        /// </summary>
        public static bool AreNear(Point2 p, Point2 q, double tolerance = 1e-12)
        {
            p=p.Normalized();
            q=q.Normalized();
            return Distance(p, q)<=tolerance;
        }
        /// <summary>
        /// Check if a point is almost on a line within tolerance
        /// </summary>
        public static bool AreNear(Point2 p, Line2 m, double tolerance = 1e-12)
        {
            p=p.Normalized();
            m=m.Normalized();
            return Distance(p, m)<=tolerance;
        }
        /// <summary>
        /// Check that two lines are almost parallel within tolerance
        /// </summary>
        public static bool AreAlmostParallel(Line2 m, Line2 n, double tolerance = 1e-12)
        {
            m=m.Normalized();
            n=n.Normalized();
            return Math.Abs(m.A*n.B-m.B*n.A)<=tolerance;
        }
        /// <summary>
        /// The point where two lines meet.
        /// </summary>
        public static Point2 Meet(Line2 m, Line2 n)
        {
            // | ma |   | na |   | (mb*nc-mc*nb) |
            // | mb | × | nb | = |-(ma*nc-mc*na) |
            // | mc |   | nc |   |  ma*nb-mb*na  |
            return new Point2(
                m.B*n.C-m.C*n.B,
                m.C*n.A-m.A*n.C,
                m.A*n.B-m.B*n.A);
        }
        /// <summary>
        /// The line joining two points
        /// </summary>
        public static Line2 Join(Point2 p, Point2 q)
        {
            // | px |   | qx |   |  (py-qy)    |
            // | py | × | qy | = | -(px-qx)    |
            // |  1 |   |  1 |   | px*qy-py*qx |
            return new Line2(
                p.V*q.W-p.W*q.V, 
                p.W*q.U-p.U*q.W, 
                p.U*q.V-p.V*q.U);
        }
        /// <summary>
        /// Calculate the cartesian distance between two points
        /// </summary>
        public static double Distance(Point2 p, Point2 q)
        {
            var u = p.U*q.W-q.U*p.W;
            var v = p.V*q.W-q.V*p.W;
            return Sqrt(u*u+v*v)/(p.W*q.W);
        }
        /// <summary>
        /// Calculate the offset of a line from a point
        /// </summary>
        public static double Distance(Line2 m, Point2 p) => Distance(p, m);
        /// <summary>
        /// Calculate the closest distance of a line to a point
        /// </summary>
        public static double Distance(Point2 p, Line2 m)
        {
            // Use the inner product `m*p = A*U+B*V+C*W`
            return Abs(m*p)/(p.W*m.Magnitude);
        }
        /// <summary>
        /// Calculate the distance between paralllel lines. 
        /// Returns 0 if lines intersect or are coincident.
        /// </summary>
        public static double Distance(Line2 m, Line2 n)
        {
            // Check that lines are parallel
            if (IsParallel(m,n))
            {
                return n.Distance-m.Distance;
            }
            // If they intersect, the distance is zero
            return 0;
        }
        /// <summary>
        /// Get point on line closet to some other point
        /// </summary>
        /// <param name="m">The line</param>
        /// <param name="p">The other point</param>
        /// <returns>A point on the line</returns>
        public static Point2 Closest(Line2 m, Point2 p)
        {
            return new Point2(
                m.B*m.B*p.U-m.A*(m.B*p.V+m.C*p.W),
                m.A*m.A*p.V-m.B*(m.A*p.U+m.C*p.W),
                p.W*(m.A*m.A+m.B*m.B));
        }
    }
