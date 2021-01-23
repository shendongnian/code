    public class Example : EntityBase
    {
    public byte RecordStatus { get; set; }
    public string RecordStatusDescription { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public string CreatorIPAddress { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime ModifiedDateTime { get; set; }
    public string ModifierIPAddress { get; set; }
    public string RemovedBy { get; set; }
    public string RemovedDateTime { get; set; }
    public string RemoverIPAddress { get; set; }
    public bool IsRemoved { get; set; }
    }
