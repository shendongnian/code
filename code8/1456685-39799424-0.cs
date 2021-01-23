    public example() {
        Packet[] array_of_packet = GetArrayofPacketFromHardware();
        var time_uS = array_of_packet.Select(p => p.time_uS).ToArray();
        var velocity = array_of_packet.Select(p => p.velocity).ToArray();
        var status_bits = array_of_packet.Select(p => p.status_word).ToArray();
        List<IPacketCollection> collection = new List<IPacketCollection> { };
        collection.Add(new TimePacketCollection(time_uS));
        collection.Add(new VelocityPacketCollection(velocity));
        collection.Add(new StatusPacketCollection(status_bits));  
        // Now we have benefits over generic objects or byte arrays.
        // We can extend our collections with additional logic as your 
        // Application grows or right now already still benefit from the 
        // GetSI you mentioned as a plus in your question.
        foreach(var velocityPacketCollection in collection.OfType<VelocityPacketCollection>()) {
            // specific velocity collection things here.
            // Also your debugger is perfectly happy peeking in the collection.
        }
        // or generic looping accessing the GetSI()
        foreach(var packetCollection in collection) {
            System.Debug.Println(packetCollection.GetSI());
        }
    }
    public interface IPacketCollection {
        /// <summary>
        /// Not sure what this method should do but it seems it 
        /// always returns double precision or something?
        /// </summary>
        public double[] GetSI;
    } 
    public class TimePacketCollection : IPacketCollection {
        private const double scaleFactor = 1.0e-6;
        private long[] timePacketArray;
        public TimePacketCollection(long[] timeArray) {
            timePacketArray = timeArray;
        }
        public double[] GetSI(){
             // no IDE available. Not sure if this automatically converts to 
             // double due to multiplication with a double.
             return timePacketArray.Select(item => scaleFactorToSI * item).ToArray();
        }
    }
    public class VelocityPacketCollection : IPacketCollection {
        private const double scaleFactor = 1/8192;
        private Int16[] velocityPacketArray;
    
        public VelocityPacketCollection (Int16[] velocities) {
            velocityPacketArray = velocities;
        }
    
        public double[] GetSI(){
             // no IDE available. Not sure if this automatically converts to 
             // double due to multiplication with a double.
             return velocityPacketArray.Select(item => scaleFactorToSI * item).ToArray();
        }
    }
    public class StatusPacketCollection : IPacketCollection {
        private const double scaleFactor = 1.0;
        private UInt32[] statusPacketArray;
    
        public StatusPacketCollection (UInt32[] statuses) {
            statusPacketArray = statuses;
        }
    
        public double[] GetSI(){
             // no IDE available. Not sure if this automatically converts to 
             // double due to multiplication with a double.
             return statusPacketArray.Select(item => scaleFactorToSI * item).ToArray();
        }
    }
