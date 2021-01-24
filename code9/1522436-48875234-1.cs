    class BiggerObj
    {
     ObjOfSetDesign Obj1 = new ObjOfSetDesign(5);
     ObjOfSetDesign Obj2 = new ObjOfSetDesign(10);
     ObjOfSetDesign Obj3 = new ObjOfSetDesign(15);
     ObjOfSetDesign Obj4;
     ObjOfSetDesign Obj5;
     public BiggerObj(int a4, int a5)
     {
      Obj4 = new ObjOfSetDesign(a4);
      Obj5 = new ObjOfSetDesign(a5);
     }
     public BiggerObj(int b4, int c4, int b5, int c5)
     {
      Obj4 = new ObjOfSetDesign(b4, c4);
      Obj5 = new ObjOfSetDesign(b5, c5);
     }
     publ BiggerObj(int d4, int e4, int f4, int d5, int e5, int f5)
     {
      Obj4 = new ObjOfSetDesign(d4, e4, f4);
      Obj5 = new ObjOfSetDesign(d5, e5, f5);
     }
    }
