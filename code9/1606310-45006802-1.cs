    class MyFace : FaceBase, IFace<string, int>
    {
        public new string ValueOne
        {
            get => base.ValueOne as string;
            set => base.ValueOne = value;
        }
        public new int ValueTwo
        {
            get => (int) base.ValueTwo;
            set => base.ValueTwo = value;
        }
        public MyFace(string valueOne, int valueTwo)
            : base(valueOne, valueTwo)
        { }
    }
