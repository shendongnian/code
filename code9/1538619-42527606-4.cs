        protected override bool OnBubbleEvent(object source, EventArgs args)
        {
            //handle bubbled event and call uc2 method
            // MyControls.uc1 is uc type -- u can check eventargs type
            if (source is MyControls.uc1)
            {
                this.uc21.RepeaterUpdate((MyEventArgs)args);
            }
            return base.OnBubbleEvent(source, args);
        }
