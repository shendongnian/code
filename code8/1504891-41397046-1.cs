              public class Tools
                  {
                 public static void FullScreenMode(Form fr) 
                {
                       fr.FormBorderStyle = FormBorderStyle.None;
                       fr.WindowState = FormWindowState.Maximized;
                        fr.Screen screen = Screen.FromPoint(Cursor.Position);
                        fr.Location = screen.Bounds.Location;
                      
  
                  }
                       }
