            class Hole : ICloneable
            {
                public Dictionary<int, double> Candidates { get; set; }
                public double PosX { get; private set; }
                public double PosY { get; private set; }
                public bool isOccupied { get; set; }
                public Hole(double posX, double posY)
                {
                    PosX = posX;
                    PosY = posY;
                    
                }
    
                public object Clone()
                {
                    var hole = new Hole(this.PosX, this.PosY)
                    {
                        isOccupied = this.isOccupied,
                        Candidates = this.Candidates
                    };
                    return hole;
                }
            }
        // and replace 
        // duration.Holes = new List<Hole>(holes);
        // to 
        duration.Holes = new List<Hole>(holes.Select(x=>x.Clone() as Hole));
