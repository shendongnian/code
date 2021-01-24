    //This method called from receiver thread 
    public void UpdateForm(Data d) 
    {
       if(this.InvokeRequired) 
       {
          this.Invoke(new MethodInvoker(() => this.UpdateFormUI(r)));
       }
       else 
       {
          this.UpdateFormUI(data)
       }
    }
   
    public void UpdateFormUI(Data d)
    {
       //Does actual ui update
    }
