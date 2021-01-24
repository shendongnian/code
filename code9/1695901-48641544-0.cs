    public class DriverAllowanceListReport
    {
        public DriverAllowanceListReport(){
             PolicyDetailList = new List<PolicyOfDriverAllowanceDetailViewModel>();
        }
        public string OrderNo { get; set; }
        public List<PolicyOfDriverAllowanceDetailViewModel> PolicyDetailList { get; set; }
    }
