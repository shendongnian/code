    if (e.EventId == AutomationElement.MenuOpenedEvent)
                {
                    timer_Chrome.Enabled = true;
                }
                else if (e.EventId == AutomationElement.MenuClosedEvent)
                {
                    timer_Chrome.Enabled = false;
                 }
