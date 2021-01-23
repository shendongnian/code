    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Drawing;
    public class MyListView : ListView
    {
        public MyListView()
        {
            EmptyText = "No data available.";
        }
        [DefaultValue("No data available.")]
        public string EmptyText { get; set; }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xF)
            {
                if (this.Items.Count == 0)
                    using (var g = Graphics.FromHwnd(this.Handle))
                        TextRenderer.DrawText(g, EmptyText, Font, ClientRectangle, ForeColor);
            }
        }
    }
