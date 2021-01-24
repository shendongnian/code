    public partial class v_apply_detail2 {
    public long apply_id { get; set; }
    public long hiring_id { get; set; }
    public string hiring_title { get; set; }
    public string publish_user_id { get; set; }
    public string publish_company_id { get; set; }
    public string user_id { get; set; }
    public Nullable<System.DateTime> pre_accept_time { get; set; }
    public sbyte join_type { get; set; }
    public Nullable<decimal> deal_pay { get; set; }
    public Nullable<System.DateTime> deal_time { get; set; }
    public Nullable<System.DateTime> start_work_time { get; set; }
    public Nullable<System.DateTime> finish_time { get; set; }
    public string master_appraise { get; set; }
    public string worker_appraise { get; set; }
    public Nullable<int> master_rating { get; set; }
    public Nullable<int> worker_rating { get; set; }
    public int status { get; set; }
    public Nullable<System.DateTime> master_rating_time { get; set; }
    public Nullable<System.DateTime> worker_rating_time { get; set; }
    public string hiring_snapshots { get; set; }
    public virtual List<yoyo_apply_timeline> time_line { get; set; }
    public member_info member_info { get; set; }
    public company_info company_info { get; set; }}
