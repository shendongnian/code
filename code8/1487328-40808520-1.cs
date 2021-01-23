     public class MyFontFactory {
       private string m_FamilyName;
       private float m_Size;
       private FontStyle m_Style;
       ...
       public MyFontFactory(Font propotype) {
         ...
         m_FamilyName = propotype.FontFamily.Name;
         m_Size = propotype.Size;
         m_Style = propotype.Style;  
       } 
       public Font Create() {
         return new Font(m_FamilyName, m_Size, m_Style);
       }
     } 
....
     MyFontFactory factory = new factory(SomeControl.Font);
     ...  
     // Much more natural
     MyControl.Font = factory.CreateFont(); 
