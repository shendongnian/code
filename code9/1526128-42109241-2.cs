        public event EventHandler<EventArgs> FormChanged;
        public virtual void ProcessChange(object sender, EventArgs e)
        {
            if((sender as Form) != this)
            {
                //Handle change
            }
        }
        protected void NotifyParent() => FormChanged?.Invoke(this, EventArgs.Empty);
