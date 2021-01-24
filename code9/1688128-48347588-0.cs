    abstract class AssemblyPart<Tin, TOut, TPrev, TNext> {
    
        AssemblyPart<TOut, TNext> Next { get; private set; }
        AssemblyPart<TPrev, TIn> Previous { get; private set; }
    
        abstract TOut OnProcess(TIn obj);
        public TOut Process(TIn obj) {
            TOut processedObj = OnProcess(obj);
            Next?.Process(processedObj);
        }
    
        public void Connect(AssemblyPart<TPrev, TIn> part){
            Next = part;
            part.Previous = this;
        }
        public void ConnectTo(AssemblyPart<TOut, TNext> part){
            Previous = part;
            part.Next = this;
        }
    
    }
