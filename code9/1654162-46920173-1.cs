    protected virtual void Dispose(bool disposing)
    {
            if (disposing && !disposed)
            {
                disposed = true;
 
                if(views != null){
                    views.Dispose();
                }
                if(attachments != null){
                    attachments.Dispose();
                }
                if(bodyView != null){
                    bodyView.Dispose();
                }
            }
        }
