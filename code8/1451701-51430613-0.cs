        [Serializable]
        public class DepartmentProgramViewModel
        {
            public DepartmentViewModel Department { get; set; }
            public ProgramViewModel Program{ get; set; }
        }
        [Serializable]
        public class DepartmentViewModel
        {
            public string WhateverProperties{ get; set; }
        }
        [Serializable]
        public class ProgramViewModel 
        {
            public string WhateverProperties{ get; set; }
        }
