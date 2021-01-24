    public interface IScrapable {
        void Scrape();
    }
    public class Proxy : IScrapeable {
        public void Scrape() { ...}
    }
