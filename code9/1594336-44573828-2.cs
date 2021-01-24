    public ulong RawModulo_5() {
        var fm = new FastModulo(1000, 5);
        ulong r = 0;
        for (uint i = 0; i < 1000; i++) {
            r += fm.Modulo(i);
        }
    }
