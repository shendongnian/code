        private void LoopThroughLabels(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                Label label = c as Label;
                if (label != null)
                {
                    if (label.AssociatedControlID == "txtEmpCd")
                    {
                        // This is your label
                    }
                }
                if (c.HasControls())
                    LoopThroughLabels(c);
            }
        }
