    class Vector3Wrap {
        private readonly Vector3 v;
        private Vector3Wrap(Vector3 v) {
            this.v = v;
        }
        public static implicit operator Vector3Wrap(Vector3 v) {
            return new Vector3Wrap(v);
        }
    	public static implicit operator Vector3(Vector3Wrap w) {
            return w.v;
        }
    }
    
    public void SetPosition(Vector3Wrap positionWrap){
        Vector3 position = positionWrap;
       // do stuff
    }
