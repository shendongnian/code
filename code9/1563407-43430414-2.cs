public static void Quadratic(double a, double b, double c) {
    <b>double delta = b*b-4*a*c;</b> //only delta
    if (<b>delta &gt;</b> 0) {
        <b>double deltaRoot = Math.Sqrt(delta);</b>
        double x1 = (-b + deltaRoot) / <b>(2 * a)</b>;  //We write the information for x1 here
        double x2 = (-b - deltaRoot) / <b>(2 * a)</b>;  //We write the information for x2 here
        Console.WriteLine("x1 = " + x1 + " x2 = " + x2); //we use this to write the roots
    } else if(delta == 0) {
        double x1 = -b/(2*a);
        Console.WriteLine("x1 = " + x1); //we use this to write the roots
    } else {
        Console.WriteLine("There are no roots");
    }
}
