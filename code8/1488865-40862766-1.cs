    public partial class MyOtherForm : Form
    {
        public MyOtherForm()
        {
            var parent = this.Parent as Form;
            if(parent != null)
                this.Title = parent.Title;
        }
    }
