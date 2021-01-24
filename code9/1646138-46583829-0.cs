            while (true)
            {
                try
                {
                    updates = await bot.GetUpdatesAsync(offset, 100, 360000);
    
                    foreach (var update in updates)
                    {
                        offset = update.Id + 1;
                        if (update.Message == null || update.Message.Text == null)
                        continue;
    
                        switch (update.Message.Text)
                        {
                            case "/start":
                                job1();
                                break;
                            case "Msg2":
                                job2();
                                break;
                            case "Msg3":
                                job3();
                                break;
                            default:
                                job(4)
                                break;
                        }
                    }
               }
               catch (ApiRequestException ex)
               {
                    //handle or ignore
               }
            }
