        public class NinjaVM
    {
        private int _id;
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            { 
                using (var context = new NinjaApp_DatabaseEntities())
                {
                    var ninja = context.ninjas.FirstOrDefault(n => n.Id == _id  ));
                    if(ninja == null)
                    return;
                    ninja.Name = value;
                    context.SaveChanges();
                }
            }
        }
