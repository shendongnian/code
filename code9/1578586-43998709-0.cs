    public class ExecutionOrder
    {
        public string Usr_id { get; set; }
        public string Patient_id { get; set; }
        public List<Execution> Executions { get; set; }
        public ExecutionOrder(string usr_id, string patient_id, List<Execution> executions)
        {
            Usr_id = usr_id;
            Patient_id = patient_id;
            Executions = executions;
        }
    }
    public class Execution
    {
        public string E_id { get; set; }
        public string E_title { get; set; }
        public string E_description { get; set; }
        public string E_date { get; set; }
        public bool E_delete { get; set; }
        public Execution(string e_id, string e_title, string e_description, string e_date, bool e_delete)
        {
            E_id = e_id;
            E_title = e_title;
            E_description = e_description;
            E_date = e_date;
            E_delete = e_delete;
        }
        
    }
