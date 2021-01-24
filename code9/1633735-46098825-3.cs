    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public event EventHandler ResponsiblePersonChanged;
        private bool _isResponsiblePerson;
        public bool IsResponsiblePerson
        {
            get => _isResponsiblePerson;
            set
            {
                _isResponsiblePerson = value;
                if (_isResponsiblePerson)
                {
                    ResponsiblePersonChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
