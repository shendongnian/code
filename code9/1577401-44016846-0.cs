     class Class1
     {
    internal class FObj_BtnRowtest
    {
        private Button[] _Btnmembers;
        public delegate void del_Btnmember(Boolean value);
        public del_Btnmember[] btnvaluechanged;
        internal class SelValue_EArgs : EventArgs//events args (selected value)
        {//return boolean arguments in events
            internal SelValue_EArgs(Boolean ivalue) { refreshed = ivalue; }//ctor
            internal Boolean refreshed { get; set; }//accessors
        }
        private Boolean[] _ActONOFFValue; 
        private Boolean ActONOFFValue(int number)
        {
            _ActONOFFValue[number] = !_ActONOFFValue[number];
            return _ActONOFFValue[number];
        }
        public FObj_BtnRowtest(int numofbtn, String UnitName)//ctor
        {
            _Btnmembers = new Button[numofbtn];
            btnvaluechanged = new del_Btnmember[numofbtn];
            _ActONOFFValue = new bool[numofbtn];
            for (int i = 0; i < numofbtn / 2; i++)
            {
               _Btnmembers[i].Click += new EventHandler(_Btnmembers_Click);
            }
        }
        protected virtual void _Btnmembers_Click(object sender, EventArgs e)
        {
            int index = Array.IndexOf(_Btnmembers, (Button)sender);
            if (btnvaluechanged[index] != null) btnvaluechanged[index](ActONOFFValue(index));
        }
     }
    }
