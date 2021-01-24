        public class brakes
        {
            private float _park_brake { get; set; }
            private float _work_brake { get; set; }
            private float _discrepancy { get; set; }
            public string park_brake
            {
                get { return _park_brake.ToString(); }
                set { _park_brake = float.Parse(value); }
            }
            public string work_brake
            {
                get { return _work_brake.ToString(); }
                set { _work_brake = float.Parse(value); }
            }
            public string discrepancy
            {
                get { return _discrepancy.ToString(); }
                set { _discrepancy = float.Parse(value); }
            }
        }
