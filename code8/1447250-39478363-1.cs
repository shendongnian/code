    private static unsafe double InternalRound(double value, int digits, MidpointRounding mode) {
        if (Abs(value) < doubleRoundLimit) {
            Double power10 = roundPower10Double[digits];
            value *= power10;
            if (mode == MidpointRounding.AwayFromZero) {                
                double fraction = SplitFractionDouble(&value); 
                if (Abs(fraction) >= 0.5d) {
                    value += Sign(fraction);
                }
            }
            else {
                // On X86 this can be inlined to just a few instructions
                value = Round(value);
            }
            value /= power10;
        }
        return value;
    }
