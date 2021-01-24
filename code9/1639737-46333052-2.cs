    public class Form1 : Form
    {
        Dictionary<string, Panel> panels = new Dictionary< string, Panel>();
        public void Form1_Load(object sender, EventArgs e)
        {
            for (var i = 0; i < 25; I++)
            {
                 Panel panel = new Panel();
                 panel.Name = "panel" + i.ToString();
                 this.Controls.Add(panel);
                 panels.Add(panel.Name, Panel);
             }
         }
    }
