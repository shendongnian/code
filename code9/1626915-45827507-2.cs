    public abstract class Drawing
    { 
        //some shapes might not be rotable or rotation
        //simply doesn't make sense: circle      
        public virtual bool CanBeRotated => true;
        public Drawing Rotate(float degree)
        {
            //Don't mutate this, return a new
            //rotated instance.
            if (!CanBeRotated) return this;
            return rotate(float);
        }
        
        //let each concrete type handle its own rotation.
        protected abstract Drawing rotate(float);
        
        //etc.
    }
