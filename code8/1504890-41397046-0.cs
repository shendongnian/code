              public class Tools
                  {
                 public static void FullScreenMode(Form fr) 
                {
                       fr.FormBorderStyle = FormBorderStyle.None;
                       fr.WindowState = FormWindowState.Maximized;
                        formInterface.Screen screen = Screen.FromPoint(Cursor.Position);
                        formInterface.Location = screen.Bounds.Location;
                      
  
                  }
                       }
