    protected async Task FillCalendarWindows()
            {
                try
                {
                    for (int r = 0; r < 6; r++)
                    {
                        for (int c = 0; c < 7; c++)
                        {
                            if (r == 0)
                            {
                                labels.Add(new Label
                                {
                                    HorizontalOptions = LayoutOptions.Center,
                                    VerticalOptions = LayoutOptions.Center,
                                    TextColor = Color.Black,
                                    FontSize = 18,
                                    FontAttributes = FontAttributes.Bold
                                });
                                DayLabels.Children.Add(labels.Last(), c, r);
                            }
                            buttons.Add(new CalendarButton
                            {
                                BorderRadius = 0,
                                BorderWidth = BorderWidth,
                                BorderColor = BorderColor,
                                FontSize = DatesFontSize,
                                BackgroundColor = DatesBackgroundColor,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                VerticalOptions = LayoutOptions.FillAndExpand
                            });
                            buttons.Last().Clicked += DateClickedEvent;
                            MainCalendar.Children.Add(buttons.Last(), c, r);
                        }
                    }
                    flag = 1;
                    //Device.BeginInvokeOnMainThread(() => CallWebService(StartDate.Month, StartDate.Year));
                    await CallWebService(StartDate.Month, StartDate.Year);
                    //CallServiceInNewTask(StartDate.Month, StartDate.Year);
                    //Device.BeginInvokeOnMainThread(() => await ChangeCalendar(CalandarChanges.All));
    
                }
                catch (Exception e)
                {
    
                }
            }
