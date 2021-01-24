    [Serializable]
    [XmlType(nameof(Departments))]
    public partial class Departments
    {
        [XmlAttribute("Name_Department")]
        public string Name_Department {
            get => Name_DepartmentCore;
            set => Name_DepartmentCore = value;
        }
        [XmlAttribute("Department_ID")]
        public int Department_ID {
            get => Department_IDCore;
            set => Department_IDCore = value;
        }
    }
