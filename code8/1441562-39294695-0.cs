    public partial class Childform : Form, Interface1
    {
        Methods_newTabPage methods;
        public Childform()
        {
            methods = new Methods_newTabPage(this);
        }
        public TabControl tabControl_Buizen_ { get { return this.tabControl_Buizen; } }
        public TabPage tabPage_plus_ { get { return this.tabPage_plus; } }
    }
