    public class cctv_camera
    {
        [AutoIncrement]
        public int I_id { get; set; }
        [Compute]
        public string I_sid { get; set; }
        public string C_store_id { get; set; }
        // .... others
    }
