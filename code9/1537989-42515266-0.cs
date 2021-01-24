    namespace project_name.Models.InvoiceViewModel
    {
        public class EditInvoiceViewModel
        {
            public int invoice_stateID { get; set; }
            public invoice invoice { get; set; }
            public List<SelectListItem> States { set; get; }
        }
    }
