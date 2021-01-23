    class SubButton : Button
        {
            public delegate void DoAction();
            public DoAction Action;
    
            public SubButton(DoAction action)
            {
                this.Action = action;
            }
    
            protected override void OnClick(EventArgs e)
            {
                Action?.Invoke(); // null propogation, no need for if statements.
                base.OnClick(e);
            }
        }
