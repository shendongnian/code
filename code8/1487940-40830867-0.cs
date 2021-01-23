    public class BackPack
    {
        private List<string> ytterFacket = new List<string>();
        public List<string> YtterFacket
        {
            get {
                return ytterFacket;
            }
        }
        private List<string> storaFacket = new List<string>();
        public List<string> StoraFacket
        {
            get {
                return storaFacket;
            }
        }
        public string PutIntoYtterFacket(string item)
        {
            if (ytterFacket.Count < 4)
            {
                ytterFacket.Add(item);
                return string.Format("Du har lagt in {0}! Tack!", item);
            }
            return string.Format("Kan inte lägge till {0}, gräns nådd", item);
        }
        public string PutIntoStoraFacket(string item)
        {
            storaFacket.Add(item);
            return string.Format("Du har lagt in {0}! Tack!", item);
        }
        public string ClearYtterFacket()
        {
            ytterFacket.Clear();
            return "Nu är ytterfacket tömt!";
        }
        public string ClearStoraFacket()
        {
            storaFacket.Clear();
            return "Nu är storafacket tömt!";
        }
    }
