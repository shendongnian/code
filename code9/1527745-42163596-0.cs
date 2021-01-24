    public interface IR_VM
    {
        int MyMethod(int param);
    }
    public class R_VM : IR_VM
    {
        public int MyMethod(int param)
        {
            // implemention
            return 0;
        }
    }
    public class VM_Main
    {
        public VM_Main(IR_VM rvm)
        {
            RVM = rvm;
        }
        public IR_VM RVM { get; set; }
    }
