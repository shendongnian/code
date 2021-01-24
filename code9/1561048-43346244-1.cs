        private Dictionary<string, int> dicControls;
        private bool isOverFlow;
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
                var max = (from Control control in Controls select control.Left + control.Width + -1).Concat(new[] { int.MinValue }).Max();
                isOverFlow = (Width - max) < 0;
            }
        }
        private void HandleDelta(int delta)
        {
            var change = ValidateChange(delta);
            foreach (Control control in Controls)
            {
                var initalLeft = dicControls[control.Name];
                var tempLeft = control.Left + change;
                if(isOverFlow)
                {
                    if (tempLeft > initalLeft || delta > 0)
                    {
                        control.Left = initalLeft;
                    }
                    else
                    {
                        control.Left += change;
                    }
                }
                else
                {
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
        }
 
