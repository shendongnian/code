    private async Task CallApi(string searchText = null)     
        {           
            long lastUpdatedTime = 0;                           
            long.TryParse(AppSettings.ComplaintLastUpdatedTick, out lastUpdatedTime);
    
            var currentTick = DateTime.UtcNow.Ticks;            
            var time = new TimeSpan(currentTick - lastUpdatedTime);
    
    
            if (time.TotalSeconds > 1)          {
                int staffFk = Convert.ToInt32(StaffId);
                var result = await mDataProvider.GetComplaintList(lastUpdatedTime, mCts.Token, staffFk);
                if (result.IsSuccess)
                {
    
                    // Save last updated time
                    AppSettings.ComplaintLastUpdatedTick = result.Data.Updated.ToString();
    
                    // Store data into database
                    if ((result.Data.Items != null) &&
                        (result.Data.Items.Count > 0))
                    {
    
                        var datas = new List<Complaint>(result.Data.Items);
    
                        if (!string.IsNullOrEmpty(searchText))
                            {
                                datas = datas.Where(i => i.Description.Contains(searchText)
                                                     && (i.SupervisorId.Equals(StaffId))
                                                    || (i.ProblemTypeName.Contains(searchText))).ToList();
                            }
                        else
                            {
                                datas = datas.Where(i => i.SupervisorId.Equals(StaffId)).ToList();
                            }
    
                        Datas = new ObservableCollection<Complaint>(datas);
                    }
                }
                else if (result.HasError)
                {
                    await mPageDialogService.DisplayAlertAsync("Error", result.ErrInfo.Message, "OK");
                }           
         }      
    }
