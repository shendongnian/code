    public class Demomodel
    {
        public List<rol_tb_approve1> rol_tb_approve1 { get; set; }
        public rol_tb_form1 rol_tb_form1 { get; set; }
    }
    public class rol_tb_approve1
    {
        public string id_form { get; set; }
        public int status { get; set; }
    }
    public class rol_tb_form1
    {
        public string id { get; set; }
        public string permasalahan { get; set; }       
    }
