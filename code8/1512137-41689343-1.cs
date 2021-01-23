      @if (Model.Holidays != null)
                {
                    var grouppedHoliday = Model.Holidays.GroupBy(summary => summary.Date.Month);
                    if (grouppedHoliday != null)
                    {
                        foreach (var holidaysummary in grouppedHoliday)
                        {
                            if (holidaysummary != null)
                            {
                                <div class="holiday-summary-subTitle">@holidaysummary.FirstOrDefault().Date.ToString("MMMM", CultureInfo.InvariantCulture)</div>
                                foreach (var holiday in holidaysummary)
                                {
                                    <div title="@holiday.Remarks" class="multiple-options">
                                        @if (holiday.IsGone == true)
                                        {
                                            <span class="is-gone-holiday-summary-day">@holiday.Date.ToString("dd", CultureInfo.InvariantCulture)</span>
                                            <span>-</span> <span class="is-gone-holiday"> @holiday.Subject</span>
                                        }
                                        else
                                        {
                                            <span class="holiday-summary-day">@holiday.Date.ToString("dd", CultureInfo.InvariantCulture)</span>
                                            <span>-</span><span class="holiday-summary-subject"> @holiday.Subject</span>
                                        }
                                    </div>                                 
                                }
                            }                        
                        }
                    }
                }
