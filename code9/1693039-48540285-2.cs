    public class JsonResponse : IHttpHandler, IRequiresSessionState
    {
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/json";
        DateTime start = new DateTime(1970, 1, 1);
        DateTime end = new DateTime(1970, 1, 1);
        start = Convert.ToDateTime(context.Request.QueryString["start"]);
        end = Convert.ToDateTime(context.Request.QueryString["end"]);
        List<int> idList = new List<int>();
        List<object> eventList = new List<object>();
        foreach (CalendarEvent cevent in EventDAO.getEvents(start, end))
        {
            eventSerializer newEvent = new eventSerializer();
            bool allDay = true;
            if (ConvertToTimestamp(cevent.start).ToString().Equals(ConvertToTimestamp(cevent.end).ToString()))
            {
                if (cevent.start.Hour == 0 && cevent.start.Minute == 0 && cevent.start.Second == 0)
                {
                    allDay = true;
                }
                else
                {
                    allDay = false;
                }
            }
            else
            {
                if (cevent.start.Hour == 0 && cevent.start.Minute == 0 && cevent.start.Second == 0
                    && cevent.end.Hour == 0 && cevent.end.Minute == 0 && cevent.end.Second == 0)
                {
                    allDay = true;
                }
                else
                {
                    allDay = false;
                }
            }
            idList.Add(cevent.id);
            newEvent.id = cevent.id;
            newEvent.title = cevent.title;
            newEvent.start = cevent.start.ToString("yyyy-MM-dd HH:mm");
            newEvent.end = cevent.end.ToString("yyyy-MM-dd HH:mm");
            newEvent.allDay = allDay;
            newEvent.description = cevent.description;
            eventList.Add(newEvent);
        }
        //store list of event ids in Session, so that it can be accessed in web methods
        context.Session["idList"] = idList;
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonData = js.Serialize(eventList);
        context.Response.Write(jsonData);
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    private long ConvertToTimestamp(DateTime value)
    {
        long epoch = (value.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        return epoch;
    }
    }
    public class eventSerializer
    {
    public int id;
    public string title;
    public string start;
    public string end;
    public bool allDay;
    public string description;
    }
