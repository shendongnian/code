    using System;
    using System.Collections.Generic;
    public class C {
        public void M() {
            IEnumerable<double> x = null;
            var y = (IEnumerator<double>)x;
        }
    }
