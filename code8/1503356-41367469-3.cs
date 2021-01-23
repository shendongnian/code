    public bool JobStatus
    {  
       get{
            return SponsorReferralUploadService.IsRunning();
       }
    }
