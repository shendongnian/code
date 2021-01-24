    public void func()
    {
         int a = 10;
         int b = 210;
         int c = 30;
         int d = 30;  
    
         // now how to do new 'new RectangleF(a,b,c,d)'
         drawFunc(a,b,c,d)
    }
    
    public void drawFunc(int aa,int bb,int cc,int dd)
    {
         IntPtr tab = tabPage2.Handle;
         Graphics g = Graphics.FromHwnd(tab);
    
         g.DrawRectangle(Pens.Navy, new Rectangle(aa, bb, cc, dd));
    }
