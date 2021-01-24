    public class MyData
    {
        public string[] Options { get; set; }
        public void SelectOption(string option)
        {
            Console.WriteLine("Option clicked: " + option);
        }
    }
        public class MyToolStripDropDownButton : ToolStripDropDownButton
    {
        public MyData Data { get; private set; }
        public MyToolStripDropDownButton():base()
        {
            this.Text = "Options";
            this.DropDownItemClicked += new ToolStripItemClickedEventHandler(MyToolStripDropDownButton_DropDownItemClicked);
        }
        public void Initialize(MyData data)
        {
            this.Data = data;
            foreach (string option in this.Data.Options)
            {
                this.DropDownItems.Add(option);
            }
        }
        void MyToolStripDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.Data.SelectOption(e.ClickedItem.Text);
        }
    }
            //..... using the code:
            MyData data = new MyData();
            data.Options = new string[] { "A", "B", "C" };
            MyToolStripDropDownButton mb1 = new MyToolStripDropDownButton();
            mb1.Initialize(data);
            MyToolStripDropDownButton mb2 = new MyToolStripDropDownButton();
            mb2.Initialize(data);
            toolStrip1.Items.Add(mb1);
            toolStrip2.Items.Add(mb2);
