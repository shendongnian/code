        //Initial case where no room has been displayed yet and panel1 is still valid
        private Panel CurrentPanel = null;
        public void SwapPanel(Panel p)
        {
            //If no panel has been placed yet, get rid of the default one
            if (panel1 != null)
            {
                //we should never need the designer panel again, so dispose it
                panel1.Dispose();
                this.Controls.Remove(panel1);
            }
            else
            {
                //we may return to this panel later, so don't dispose it
                this.Controls.Remove(CurrentPanel);
            }
            CurrentPanel = p;
            this.Controls.Add(p);
        }
