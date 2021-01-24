    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public class Activity
        {
            public int ID { get; set; }
            public int IncidentID { get; set; }
            public string Description { get; set; }
            public int TimeSpent { get; set; }
    
            public static int StartX { get; set; } = 10;
            public static int StartY { get; set; } = 10;
            public Activity(int iD, int incidentID, string description, int timeSpent)
            {
                this.ID = iD;
                this.IncidentID = incidentID;
                this.Description = description;
                this.TimeSpent = timeSpent;
            }
            public void DrawToForm(Form f)
            {
    
                var label = new Label();
                var textBox = new TextBox();
                var checkBox = new CheckBox();
                label.Text = Description.ToString();
                textBox.Text = TimeSpent.ToString();
                label.Left = StartX;
                label.Top = StartY;
                StartX += 100;// Move position to right
                textBox.Left = StartX;
                textBox.Top = StartY;
                StartX += 150;// Move position to right
                checkBox.Left = StartX;
                checkBox.Top = StartY;
                StartX = 10;// Reset to start
                StartY += 50;// Move position to down
                f.Controls.Add(label);
                f.Controls.Add(textBox);
                f.Controls.Add(checkBox);
            }
        }
    }
