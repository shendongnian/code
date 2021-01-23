     // Simplest, but not thread safe
     private static Random random = new Random();
     string IGenerateOtpCodeService.GenerateOtpCode() {
       var ops = new HashSet<int>(personalTestSessionRepository
         .FindAll(x => x.State == PersonalTestSessionStates.NotStarted)
         .Select(x => x.Person.Otp));
       int value = -1;
       while (true) {
         value = random.Next(10000000);
         if (!ops.Contains(value)) 
           return value.ToString();
       }
     }  
