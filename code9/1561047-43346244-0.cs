        private Dictionary<string, int> dicControls;
        protected override void InitLayout()
        {
            base.InitLayout();
            if (dicControls == null)
            {
                dicControls = new Dictionary<string, int>();
                foreach (Control control in Controls)
                {
                    dicControls.Add(control.Name, control.Left);
                }
            }
        }
        private void HandleDelta(int delta)
        {
            var change = ValidateChange(delta);
            foreach (Control control in Controls)
            {
                var initalLeft = dicControls[control.Name];
                var tempLeft = control.Left + change;
                if (tempLeft < initalLeft)
                {
                    control.Left = initalLeft;
                }
                else
                {
                    control.Left += change;
                }
            }
        }
