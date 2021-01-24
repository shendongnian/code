    private Object thisLock = new Object();
    public void f() {
        lock (thisLock) {
            if (dictionary == null) {
                dictionary = new ConcurrentDictionary();
            }
        }
    }
