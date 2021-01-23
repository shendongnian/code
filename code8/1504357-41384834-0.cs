    public class DBContext
    {
        List<Model> objModel = new List<Model>();
       public List<Model> GetData()
        {
            objModel.Add(new Model
            {
                Name = "Manish",Age = 27,Sports = "Cricket"
            });
            objModel.Add(new Model
            {
                Name = "Rajan",Age = 25,Sports = "FootBall"
            });
            objModel.Add(new Model
            {
                Name = "Prashant", Age = 25,Sports = "Kabaddi"
            });
            objModel.Add(new Model
            {
                Name = "Garima", Age = 24,Sports = "Ludo"
            });
            objModel.Add(new Model
            {
                Name = "Neha",Age = 25,Sports = "Carom"
            });
            return objModel;
        }
    }
