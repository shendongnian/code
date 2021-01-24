    public class ClsPayeDetails
    {
        //Your property class
    
        public override string ToString()
        {
            System.Text.StringBuilder val = new System.Text.StringBuilder();
            val.Append(string.Format("reducing_value = {0},", reducing_value));
            val.Append(string.Format("financial_year = {0},", financial_year));
            val.Append(string.Format("lower_limit = {0},", lower_limit));
            val.Append(string.Format("upper_limit = {0},", upper_limit));
            val.Append(string.Format("percentage = {0},", percentage));
            return val.ToString();
        }
    }
