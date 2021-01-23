     public class BaseViewModel
      {
         /// add members
      }
        
     public class TaskViewModel : BaseViewModel
     {
         /// add members
     }
        
     public class TaskReviewViewModel : BaseViewModel
     {
        /// add members
     }
    
    
      private bool CompareTask<T>(Models.Task model)
                where T:BaseViewModel
      {
          var instance = Activator.CreateInstance<T>();
                ....
      }
