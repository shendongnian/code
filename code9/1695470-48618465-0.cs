    public class Geometry<TCord> where TCord : Cords
    {
        public void InitCords(){
            points = new List<TCord>();
        }
        public virtual void SomeMathWithPoints(){
             MagicWithPoints(points);
        };
    
        protected List<TCord> points;
    }
