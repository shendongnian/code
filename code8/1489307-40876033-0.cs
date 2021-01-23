    public class PieRepository
    {
        public void AddCherryPie(string incredientA)
        {
            try{
                ...
            }
            catch(Exception ex){
                log("Error in AddCherryPie(" + incredientA + ")");
                throw
            }
        }
