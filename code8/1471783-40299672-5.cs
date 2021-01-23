    string IGenerateOtpCodeService.GenerateOtpCode() {
       var ops = personalTestSessionRepository
         .FindAll(x => x.State == PersonalTestSessionStates.NotStarted)
         .Select(x => x.Person.Otp)
         .OrderBy(x => x);
 
       bool first = true;
       int prior = -1;
       foreach (var item in ops) {
         if (!first && item != prior + 1)
           return item.ToString();
         first = false;
         prior = item; 
       }    
       // no holes, we might want to return the last item + 1
       return (prior + 1).ToString();
    }
