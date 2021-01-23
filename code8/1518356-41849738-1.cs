        public CPUReadActor()
        {
            Receive<ReadCPURequestMessage>(msg => ReceiveReadDataMessage());
            Receive<ReadCPUSyncMessage>(msg => ReceiveSyncMessage(msg));
        }
        private void ReceiveSyncMessage(ReadCPUSyncMessage msg)
        {
            switch (msg.Op)
            {
                case SyncOp.Start:
                    OnCommandStart();
                    break;
                case SyncOp.Stop:
                    OnCommandStop();
                    break;
                default:
                    throw new Exception("unknown Op " + msg.Op.ToString());
            }
        }
