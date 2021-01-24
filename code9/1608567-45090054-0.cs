    CreateMap<GetClinicsByUserName_Result, ClinicListViewModel>()
    .ForMember(d => d.ProgressBarCssClass , o => o.ResolveUsing(s =>
    {
        //Do your custom logic here.
    }))
    .AfterMap((src, dest) =>
    {
       //Do your logical after mapping has been done
        dest.ProgressBarCssClass = string.Empty;
        if (dest.PercentComplete == 100)
        {
           dest.ProgressBarCssClass = "progress-bar-success";
        }
        else if (DateTime.Now.Subtract(dest.BillerStartDateTime ?? 
        DateTime.Now).TotalDays > MaxDaysInDataEntry)
        {
           // partial is a warning color
           dest.ProgressBarCssClass = "progress-bar-partial";
        }      
    });
