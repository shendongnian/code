        [Serializable]
        public class _ev_backend
        {
            public int evntID {get; set;};
            public int PositionX {get; set;};
            public int PosotionY {get; set;};
            public List<string> ComCode {get; set;};
            public byte[] EventGraphics  {get; set;};
            
            [NonSerialized]
            public List<Graphics.Node> NodeGraph {get; set;}; //Editor only information
            public List<pages> Pages {get; set;};
            public List<EventItem> Event {get; set;};
        }
        [Serializable]
        public class _ev_client
        {
            public int evntID {get; set;};
            public int PositionX {get; set;};
            public int PosotionY {get; set;};
            public List<string> ComCode {get; set;};
            public byte[] EventGraphics  {get; set;};
            public List<pages> Pages {get; set;};
            public List<EventItem> Event {get; set;};
        }
