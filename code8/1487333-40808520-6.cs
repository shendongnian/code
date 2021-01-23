     public class MyFontStorage: IDisposable {
       private Font m_MyFont; 
       ... 
       public Font MyFont {
         get {
           return m_MyFont; 
         } 
         set {
           if (m_MyFont == value)
             return;
           if (m_MyFont != null)
             m_MyFont.Dispose();
           m_MyFont = value;             
         }  
       }
       protected virtual void Dispose(bool disposing) {
         if (disposing) {
           MyFont = null;
         }
       }
       public void Dispose() {
         Dispose(this);
         GC.SuppressFinalize(this); 
       } 
     }
....
     using (MyFontStorage storage = new MyFontStorage()) {
       ...
       // Storage is responsible for the font
       storage.MyFont = new Font(...);
       ...
       // Control has responsibility for the font as well, that's why
       // we have to create a copy in order to each font instance has one owner
       MyControl.Font = new Font(MyFontStorage.MyFont, MyFontStorage.Font.Style);  
       ... 
     }  
