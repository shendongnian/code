    if (e.CmsData.Skill.InQueueInRing > 0)
                        {
                            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() => { callsWaitingData.Text = e.CmsData.Skill.InQueueInRing.ToString();
    
                                callsWaitingData.Foreground = new SolidColorBrush(Colors.Red); }));
                                                  
                        }
                        else if (e.CmsData.Skill.AgentsAvailable > 0)
                        {                        
                            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() => { callsWaitingData.Text = e.CmsData.Skill.AgentsAvailable.ToString();
                                callsWaitingData.Foreground = new SolidColorBrush(Colors.Green);}));                        
                        }
                        else if(e.CmsData.Skill.AgentsAvailable == 0)
                        {
                            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() => { callsWaitingData.Text = e.CmsData.Skill.AgentsAvailable.ToString();
                                callsWaitingData.Foreground = new SolidColorBrush(Colors.Yellow); }));
                            
                        }
