    public class Messenger {
        private readonly BackgroundWorker online_mode_send_worker = new BackgroundWorker();
        private readonly ConcurrentQueue<object> messages;
        public Messenger() {
            messages = new ConcurrentQueue<object>();
            online_mode_send_worker.DoWork += online_mode_send_worker_DoWork;
            online_mode_send_worker.RunWorkerCompleted += online_mode_send_worker_RunWorkerCompleted;
        }
        public void SendAsync(object message) {
            if (online_mode_send_worker.IsBusy) {
                messages.Enqueue(message);
            } else {
                online_mode_send_worker.RunWorkerAsync(message);
            }
        }
        public Action<object> MessageHandler = delegate { };
        private void online_mode_send_worker_DoWork(object sender, DoWorkEventArgs e) {
            if (MessageHandler != null)
                MessageHandler(e.Argument);
        }
        private void online_mode_send_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            object nextMessage = null;
            if (messages.Count > 0 && messages.TryDequeue(out nextMessage)) {
                online_mode_send_worker.RunWorkerAsync(nextMessage);
            }
        }
    }
    
