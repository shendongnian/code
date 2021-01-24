    public class MyFragment:Fragment
    {
        ...
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            //add global layout event listener
            view.ViewTreeObserver.GlobalLayout += ViewTreeObserver_GlobalLayout;
        }
        private void ViewTreeObserver_GlobalLayout(object sender, EventArgs e)
        {
            //get the size of fragment
            var width=this.View.Width;
            var height = this.View.Height;
        }
    }
