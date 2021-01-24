    public class MyForm : Form
    {
        protected override void DestroyHandle()
        {
            if (!Modal || Disposing)
                base.DestroyHandle();
        }
    }
