    public class UserTransactionByIdComaprer : IEquialityComparer<UserTransaction>
    {
         pulic static readonly IEquialityComparer<UserTransaction> Instance = new UserTransactionByIdComaprer()
         public bool Equal(UserTransaction x, UserTransaction y)
         {
             return x.TransactionId == y.TransactionId;
         }
         public int GetHashCode(UserTransaction x)
         {
              return x.TransactionId.GetHashCode();
         }
    
    }
    
    var prepared = ....
    var old = ...
    
    var diff = prepared.Except(old, UserTransactionByIdComaprer.Instance); // this are all that are not present in the old list
