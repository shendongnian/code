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
     Length = misc.EmSizeInMillimeters * 3.0f + 15.0f;
