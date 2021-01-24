    class ObjOfSetDesign
    {
     int A, B, C, D, E, F;
     int X = 90;
     int Y = 45;
     int Z = 75;
    
    public ObjOfSetDesign(int a)
    {
     A = a;
     D = a / 5;
     B = (A + D) * 2;
     C = B * 6;
     E = A * 4;
     F = C / 2;
    }
    public ObjOfSetDesign(int b, int c)
    {
     B = b;
     C = c;
     D = b / 12;
     A = D * 5;
     E = A * 4;
     F = c / 2;
    }
    public ObjOfSetDesign (int d, int e, int f)
    {
     D = d;
     E = e;
     F = f;
     A = d * 5;
     C = f * 2;
     B = c / 6;
    }
