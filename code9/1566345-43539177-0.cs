     public class Constants
     {
        public enum ReturnCode
        {
            Fail = -1,
            Success = 0,
            Warning = 1
        }
     }
     
     public static T DirectCast<T>(object o)
        {
            T value= (T)o;
            if (value== null && o != null)
            {
                throw new InvalidCastException();
            }
            return value;
        }
     
     code = Constants.DirectCast<Constants.ReturnCode>(int.Parse(db.GetParameterValue(command, "RESULTCODE").ToString().Trim()));
