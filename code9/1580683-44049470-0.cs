    interface IQuant {
        QuantTypes QuantType { get; }
    }
    class QuantWeight {
        public QuantTypes QuantType {
            get { return QuantTypes.Weight; }
        }
        public double QuantWeightValue { get; }
    }
    class QuantCount {
        public QuantTypes QuantType {
            get { return QuantTypes.Pieces; }
        }
        public int PiecesValue { get; }
    }
