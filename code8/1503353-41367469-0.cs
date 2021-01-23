    public Visibility JobStatus
    {
       get
       {
           if(SponsorReferralUploadService.IsRunning())
               return Visibililty.Collapsed;
           else
               return Visibililty.Visible;    
       }
    }
