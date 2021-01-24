    public abstract class ParentForm : Form
    {
        public int DeliveryId { get; set; }
        public int CustomerId { get; set; }
        public int Year { get; set; }
    }
    public class FormEng : ParentForm
    {
    }
    public class FormGer : ParentForm
    {
    }
