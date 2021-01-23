    class Frequencies
    {
        // HelperClass
        private class Frequency: IFrequency
        {
            public string Name { get;  set; }
            public OctaveGroups Octave { get; set; }
        }
        public readonly static List<IFrequency> All = new List<IFrequency>
        {
        #region Complete Frequencies Data
                new Frequency { Name = "63", Hz = 63,
                    Octave = OctaveGroups.oneOctave | OctaveGroups.None,
                    },
                new Frequency { Name = "80", Hz = 80,
                    Octave = OctaveGroups.None,
                    }
           // And so on..
                //..
        #endregion
        };
        public readonly List<IFrequency> OneOctave = All.Where(f => f.Octave.HasFlag(OctaveGroups.oneOctave)).ToList();
        public readonly List<IFrequency> None = All.Where(f => f.Octave.HasFlag(OctaveGroups.None)).ToList();
    }
