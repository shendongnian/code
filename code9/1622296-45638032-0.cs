        protected override void OnInit(EventArgs e)
        {
            if (Context.Items.Contains("MyCustomControl"))
                throw new Exception("only one instance of a MyCustomControl can be added to the page");
            Context.Items["MyCustomControl"] = true;
            base.OnInit(e);
            
        }
