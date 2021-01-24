    public override void ViewDestroy(bool viewFinishing = true)
    {
            base.ViewDestroy(viewFinishing);
            this.InitializeTask.PropertyChanged -= this.InitializeTask_PropertyChanged;
    }
  
