    public class PrimeChecker {
        private IPrimeDb primeDb;
        public PrimeChecker(IPrimeDb db) {
            this.primeDb = db;
        }
        public bool IsPrime(int num) {
            if (num < 2) {
                return false;
            }
            if (num > 2 && num % 2 == 0) {
                return false;
            }
            if (num % 2 != 0) {
                for (int i = 3; (i * i) <= num; i += 2) {
                    if (num % i == 0) {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool Save(int prime) {
            if (IsPrime(prime))
                return primeDb.Save(prime);
            return false;
        }
    }
