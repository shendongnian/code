    public class OP:CM
    {
        private TTC ttcobject;
        //you can inject it
        public OP(TTC _ttc){
            this.ttcobject = _ttc;
            // or just initialize it here
            // ttcobject = new TTC();
        }
        public bool CanSave(object parameter)
        {
            return ttc.CanSave(parameter;
        }
    }
