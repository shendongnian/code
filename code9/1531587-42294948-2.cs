    public class Form1 : Form
    {
        public List<Actor> Actors = new List<Actor>();
        public void Add()
        {
            //creating new actor based on input + adding to collection
            var lAct = new Actor() { X = 10, Y = 20, Name = "Actor1" };
            Actors.Add(lAct);
            NotifyRedraw();
        }
        public void Remove(string aName)
        {
            var lAct = Actors.FirstOrDefault( a => a.Name == aName);
            if (lAct != null)
                Actors.Remove(lAct);
            NotifyRedraw();
        }
        public void NotifyRedraw()
        {
            this.panel1.Refresh();
        }
        /* call methods above from clicking the buttons*/
        public void Draw(Graphics g)
        {
            g.Clear(); //clear the graphics to make fresh drawing
            foreach (Actor a in Actors)
            {
                g.DrawCircle( /* implementation of drawing Actor */);
                foreach(UseCase u in a)
                {
                    g.DrawRectangle( /* implementation of drawing UseCase */ );
                    g.DrawLine(Pens.Red, a.X, a.Y, u.X, u.Y); //implementation of drawing Relation
                }
            }
        }
    }
