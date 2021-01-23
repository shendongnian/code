    Messenger messenger;
    private ServiceConnection serviceConnection = new ServiceConnection() {
        public void onServiceConnected(ComponentName className, IBinder iBinder) {
            messenger = new Messenger(iBinder);
        }
        public void onServiceDisconnected(ComponentName className) {
        }
    };
