    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CtrlWord1
    {
        private Int16 _backingField;
        private void SetBitfield(Int16 mask, bool value)
        {
            if (value)
            {
                _backingField = (Int16)(_backingField | mask);
            }
            else
            {
                _backingField = (Int16)(_backingField & ~mask);
            }
        }
        private bool GetBitfield(Int16 mask)
        {
            return (_backingField & A1_MASK) != 0;
        }
        private const Int16 A1_MASK = 1 << 0;
        public bool a1
        {
            get { return GetBitfield(A1_MASK); }
            set { SetBitfield(A1_MASK, value); }
        }
        private const Int16 A2_MASK = 1 << 1;
        public bool a2
        {
            get { return GetBitfield(A2_MASK); }
            set { SetBitfield(A2_MASK, value); }
        }
        private const Int16 A3_MASK = 1 << 2;
        public bool a3
        {
            get { return GetBitfield(A3_MASK); }
            set { SetBitfield(A3_MASK, value); }
        }
        private const Int16 A4_MASK = 1 << 3;
        public bool a4
        {
            get { return GetBitfield(A4_MASK); }
            set { SetBitfield(A4_MASK, value); }
        }
       
        //And so on
    }
