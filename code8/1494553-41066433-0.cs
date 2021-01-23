    private class servicetimeofday
    {
    public int servicetimeofdayid { get; set; }
    public int serviceid { get; set; }
    public int timeofdayid { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    List<servicetimeofday> servicetimesofday = new List<servicetimeofday>
    {
    new servicetimeofday() { servicetimeofdayid = 1, serviceid = 1, timeofdayid = 1 },
    new servicetimeofday() { servicetimeofdayid = 2, serviceid = 1, timeofdayid = 2 },
    new servicetimeofday() { servicetimeofdayid = 3, serviceid = 2, timeofdayid = 1 },
    new servicetimeofday() { servicetimeofdayid = 4, serviceid = 2, timeofdayid = 3 }
    };
    var itemstocheck = from s in servicetimesofday
    where s.serviceid == 2
    select s.servicetimeofdayid;
    (from i in CheckBoxList2.Items.Cast<ListItem>() 
    where itemstocheck.Contains(Convert.ToInt32(i.Value))
    select i).ToList().ForEach(i => i.Selected = true);
    }
