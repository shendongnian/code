    short testArithmetic = 1;
            // This gives us the result that 1 / 2 = 0.
            testArithmetic /= 2;
            // Set this back to 1 for the next operation
            testArithmetic = 1;
            // This is 0.0 too!
            double testArithmeticFloat = testArithmetic / 2;
            // This gives us the result we'd expect
            testArithmeticFloat = 1.0 / 2.0;
            // This'll compile just fine, but you get a DivideByZeroException when you try to execute it
            testArithmetic /= 0;
