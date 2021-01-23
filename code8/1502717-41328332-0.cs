    foreach (result rs in gg.result)
      {
         try
            {
    
             if ((BotTelegramWeb.TaktopBot.message.Equals(rs,null))==false)
               {
                 results.Add(rs);
                 SendMessage(rs.message.chat.id.ToString(), "hello" +rs.message.chat.first_name); 
                }
              else
                {
                  continue;
                }
              }
    
    
                catch (Exception ex)
                  {
                    throw;
                   }
    
              } 
