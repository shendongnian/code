     public void Post(Message message)
            {
                CreateRecordsInCrm c = new CreateRecordsInCrm();
                // Check if message is not null , then next condition 
               if (message != null &&  message.Current != null && message.Current.pipeline_id == 1)
                {
                    c.CheckCondition(message);
                } else{
                  // message or Current object is null
                }
        
            }
        }
