        [Serializable]
        public class _light
        {
            public int id {get; set;};
            public float Color1 {get; set;};
            public float Color2 {get; set;};
            public float Color3 {get; set;};
            public float Color4 {get; set;};
            public float Power {get; set;};
            public int decay {get; set;};
            public float x {get; set;};
            public float y {get; set;};
            public float z {get; set;};
            public bool enabled {get; set;};
        }
        [Serializable]
        public class _ev
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
