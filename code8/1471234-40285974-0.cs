    namespace Yoda.Data.Interfaces.Enums
    {
      using System.ComponentModel.DataAnnotations;
      using Yoda.Data.Interfaces.Properties;
      public enum QuestionType
      {
        [Display(Name = "Question_Type_Unknown_Entry",
                 ResourceType = typeof(Resources),
                 Description = "Question_Type_Unknown_ToolTip")]
        Unknown = 0,
        [Display(Name = "Question_Type_Question_Entry",
                 ResourceType = typeof(Resources),
                 Description = "Question_Type_Question_ToolTip")]
        Question = 1,
        [Display(Name = "Question_Type_Answer_Entry",
                 ResourceType = typeof(Resources),
                 Description = "Question_Type_Answer_ToolTip")]
        Answer = 2
      }
    }
