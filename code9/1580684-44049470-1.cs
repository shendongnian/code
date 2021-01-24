    public void ProcessQuant(IQuant quant) {
        ProcessQuantImpl((dynamic)quant);
    }
    private void ProcessQuantImpl(QuantWeight weight) {
        ... // Do the real work here
    }
    private void ProcessQuantImpl(QuantCount pieces) {
        ... // Do the real work here
    }
