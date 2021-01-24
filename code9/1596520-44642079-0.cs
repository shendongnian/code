    private ConcurrentQueue<Packet> _queue = new ConcurrentQueue<Packet>();
    private volatile bool _cancel;
    void Listener() {
        while (!_cancel) {
            var packet = GetNextPacket(out packet);
            _queue.Enqueue(packet);
        }
    void Processor() {
        while (!_cancel) {
            Packet packet;
            var ok = _queue.TryDequeue(out packet);
            if (ok) {
                SaveToDatabase(packet);
            }
            else {
                Sleep(100);
            }
        }
    }
