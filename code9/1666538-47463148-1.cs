       ExternalData.Field1.Changed( _ => ScheduleUpdate());
       bool calculationInProgress = false;
       bool updatePending = false;
       void ScheduleUpdate()
       {
           updatePending = true;
           if (calculationInProgress)
           {
              return;
           }
            
           calculationInProgress = true;
           updatePending = false;
           service.ComputeAll(num1, num2,
              () => 
              {
                    calculationInProgress = false;
                    UpdateUI();       
                    if (updatePending)
                    {
                       ScheduleUpdate();
                    }
              });
       }
