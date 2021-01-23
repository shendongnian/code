            protected override void OnPaint(PaintEventArgs e)
        {
            // Call the OnPaint method of the base class.
            base.OnPaint(e);
            List<Rectanglestring> testrecs = new List<Rectanglestring>();
            testrecs.Add(new Rectanglestring { targetrect = new Rectangle(0, 12, 40, 12), whattodraw = "" });
            testrecs.Add(new Rectanglestring {targetrect= new Rectangle(0, 25, 35, 12),whattodraw="" });
            testrecs.Add(new Rectanglestring { targetrect = new Rectangle(0, 35, 35, 12), whattodraw = "" });
            testrecs.Add(new Rectanglestring { targetrect = new Rectangle(0, 45, 35, 12), whattodraw = "" });
            testrecs.Add(new Rectanglestring { targetrect = new Rectangle(0, 65, 35, 12), whattodraw = "" });
            testrecs.Add(new Rectanglestring { targetrect = new Rectangle(0, 85, 35, 12), whattodraw = "" });
            testrecs.Add(new Rectanglestring { targetrect = new Rectangle(0, 95, 55, 12), whattodraw = "" });
            string mystringtofit = "This is just an example";
           
            foreach (Rectanglestring rect in testrecs)
            {
                for (int i = 0; i < mystringtofit.Length; i++)
                {
                    if (mystringtofit[i] == ' ' && rect.whattodraw.Length > 0) break;
                    if (mystringtofit[i] == ' ') continue;
                    string teststring = rect.whattodraw + mystringtofit[i];
                    SizeF stringSize = stringSize = e.Graphics.MeasureString(teststring, new Font("Ariel", 12));
                    if (stringSize.Width >= rect.targetrect.Width) break;
                    rect.whattodraw += mystringtofit[i];
                }
                
                mystringtofit = mystringtofit.Substring(rect.whattodraw.Length);
                if (mystringtofit.StartsWith(" "))
                {
                    mystringtofit = mystringtofit.Substring(1);
                }
                e.Graphics.DrawString(rect.whattodraw, Font, new SolidBrush(ForeColor), rect.targetrect);
            }
            // Call methods of the System.Drawing.Graphics object.
            
        }
        public class Rectanglestring
        {
           public Rectangle targetrect = new Rectangle();
           public string whattodraw = "";
        }
