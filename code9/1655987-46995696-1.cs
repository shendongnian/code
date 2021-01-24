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
                    var ninja = context.ninjas.First(n => n.Id == _id  ));
                    ninja.Name = value;
                    context.SaveChanges();
                }
                _name = value;
            }
        }
