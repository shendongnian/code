    public struct AServiceOptions {
    }
    public struct ADerivedServiceOptions : AServiceOptions { // Not possible
    }
    public class AService {
        public AService(AServiceOptions opt) ...
    }
    public class ADerivedService {
        public ADerivedService (ADerivedServiceOptions opt) ...
    }
