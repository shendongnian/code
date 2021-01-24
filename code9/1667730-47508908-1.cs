    private Input[] _inputs;
    public Node(int numInputs = 1) {
        _inputs = new Input[numInputs];
        for(int i = 0 ; i < _inputs.Length ; i++) {
            _inputs[i] = new Input();
        }
    }
