        public class SaleService
        {
           public async Task<string> GetValue(IQuestionBox qbox)
           {
              if (await qbox.ShowYesNoQuestionBox("Do you think Edney is the big guy ?"))
              {
                   return "I knew, Edney is the big guy";
              }
              return "No I disagree";
           }
        }
