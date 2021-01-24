        public class Enemy
        {
            string[] baseLikes = new string[] { "loitering", "puppies" };
    
            public virtual string[] GetLikes()
            {
               return baseLikes;
            }
        }
    
        public class Skater : Enemy
        {
            string[] uniqueLikes = new string[] { "skateboarding" };
    
            public override string[] GetLikes()
            {
                string[] likes = base.GetLikes();
                return likes.Concat(uniqueLikes).ToArray();
            }
        }
