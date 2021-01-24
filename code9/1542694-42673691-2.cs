    public class MyToolStripDropDownButton : ToolStripDropDownButton
    {
        public MyData Data { get; private set; }
        public MyToolStripDropDownButton():base()
        {
            this.Text = "Options";
        }
        public void Initialize(MyData data)
        {
            this.Data = data;
            this.Data.ElementsToNotify.Add(this);
            foreach (string option in this.Data.Options.Keys)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(option);
                item.CheckOnClick = true;
                item.CheckedChanged += new EventHandler(item_CheckedChanged);
                this.DropDownItems.Add(item);
            }
        }
        void item_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            this.Data.OnSelectOption(item.Text, item.Checked);
        }
    }
    public class MyData
    {
        public List<MyToolStripDropDownButton> ElementsToNotify { get; private set; }
        public Dictionary<string, bool> Options { get; private set; }
        public MyData()
        {
            this.Options = new Dictionary<string, bool>();
            this.ElementsToNotify = new List<MyToolStripDropDownButton>();
        }
        public void OnSelectOption(string option, bool isChecked)
        {
            Options[option]=isChecked;
            foreach (MyToolStripDropDownButton btn in ElementsToNotify)
            {
                foreach(ToolStripMenuItem  item in btn.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    item.Checked = Options[item.Text];
                }
            }
        }
    }
  // .......................
            MyData data = new MyData();
            data.Options.Add("A", false);
            data.Options.Add("B", false);
            data.Options.Add("C", false);
            MyToolStripDropDownButton mb1 = new MyToolStripDropDownButton();
            mb1.Initialize(data);
            MyToolStripDropDownButton mb2 = new MyToolStripDropDownButton();
            mb2.Initialize(data);
            toolStrip1.Items.Add(mb1);
            toolStrip2.Items.Add(mb2);
