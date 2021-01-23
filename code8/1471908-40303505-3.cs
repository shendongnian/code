    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        Task.Factory.StartNew(() =>
        {
            try
            {
                doWork();
            }
            catch (Exception exception)
            {
                this.BeginInvoke(new Action(() => { throw new InvalidOperationException("Exception in doWork()", exception); }));
            }
            finally
            {
                this.BeginInvoke(new Action(this.Close));
            }
        });
    }
