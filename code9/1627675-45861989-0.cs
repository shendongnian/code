    public /*abstract*/ class BaseForm : Form
    { 
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Console.WriteLine($"Entered {this.GetType().Name}");
        }
    }
