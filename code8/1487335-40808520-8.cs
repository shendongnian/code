     public class MyFontMisc {
       private Font m_MyFont;
       public Font MyFont {
         get {
           return m_MyFont; 
         } 
         set {
           m_MyFont = value;             
         }  
       }
       // Just some computations
       public float EmSizeInMillimeters {
         get {
           if (null == m_MyFont)
             return 0.0;
           ...
         }  
       }
     } 
......
     // MyFontMisc doesn't hold any responsibility for the font  
     MyFontMisc misc = new MyFontMisc(SomeControl.Font); 
     // MyFontMisc just uses font for some computation and doesn't take 
     // any responsibility for the font (which owns to SomeControl) 
     Length = misc.EmSizeInMillimeters * 3.0f + 15.0f;
