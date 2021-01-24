    public sealed class GearCollection : List<Gear>
    {        
        public void Update()
        {
            foreach (var gear in this)
                gear.Update();
        }
    }
