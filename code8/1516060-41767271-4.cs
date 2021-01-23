        // why not static?
        private string getCompleteCode(string code)
        {
            // what does "b1" as well as "b2" stand for?
            var b1 = 10;
            var b2 = 20;
            var sum = 0;
            // the reason for the loop being in reversed order? 
            for (var i = code.Length - 1; i >= 0; i--) 
            {
                // the question put - what does 0x30 stand for - it's ascii code of '0' char 
                // so, why magic code 0x30 instead of evident '0'?
                var z = code[i] - 0x30;
                sum = sum + (z + b1) * b2;
            }
            // what if I want to compute it in, say, WinForms?? 
            // Never mix business logic (computing some code) and UI (output) 
            Console.WriteLine(sum);
            // we've done a lot of stuff just to return the initial input?? 
            return code;
        } 
