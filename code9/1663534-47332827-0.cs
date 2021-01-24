    public class EventItem
    {
    public int Id { get; set; } = -1;
    public int ClientId { get; set; }
    public EventItem(IDataRecord rdr)
    {
        FillAttributs(rdr);
    }
    public virtual void FillAttributs(IDataRecord rdr)
    {
        this.Id = (int)rdr["EventId"];
        this.ClientId = (int)rdr["ClientId"];
    }
    }
    public class ControlItem : EventItem
    {
    public int ControlId { get; set; }
    public ControlItem(IDataRecord rdr) : base(rdr)
    {
        //FillAttributs(rdr);
    }
    public override void FillAttributs(IDataRecord rdr)
    {
        base.FillAttributs(rdr); // Version 1
        this.ControlId = (int)rdr["ControlId"];
    }
    }
    ...
    ControlItem ctrl = new ControlItem(rdr)
