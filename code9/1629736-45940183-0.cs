        <select class="form-control dropdown guestTitle">
        @{
           TimeSpan StartTime = TimeSpan.FromHours(0);
           <option>00:00</option>
           for (int i = 0; i < 24; i++)
               {
                   StartTime = StartTime.Add(new TimeSpan(00,30,0));
                   <option>@StartTime.ToString("HH:mm")</option>
               }                      
          }                                                                                           
      </select>
