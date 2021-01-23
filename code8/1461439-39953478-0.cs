    public string getHistoryRange(string strVar0 = "", string strVar1 = "", string strVar2 = "", dynamic strVar3 = null)
            {
                string res = "";
                using (DeskAlertsDbContext db = new DeskAlertsDbContext())
                {
    
                    var alerts = db.HistoryAlerts.OrderBy(a => a.ReciveTime)
                        .Include(b => b.alert.WINDOW)
                        .ToList();
                    foreach (var alert in alerts)
                    {
    
                        res += ("{\"id\":" + System.Web.HttpUtility.JavaScriptStringEncode(alert.alert.Alert_id) +
                                ",\"date\":\"" +
                                System.Web.HttpUtility.JavaScriptStringEncode(
                                    alert.ReciveTime.ToString(CultureInfo.InvariantCulture)) + "\",\"alert\":\"" +
                                System.Web.HttpUtility.JavaScriptStringEncode(alert.alerttext) + "\",\"title\":\"" +
                                System.Web.HttpUtility.JavaScriptStringEncode(alert.alert.Title) + "\",\"acknow\":\"" +
                                System.Web.HttpUtility.JavaScriptStringEncode(alert.alert.Acknown) + "\",\"create\":\"" +
                                System.Web.HttpUtility.JavaScriptStringEncode(alert.alert.Create_date) + "\",\"class\":\"" +
                                "1" + "\",\"urgent\":\"" + System.Web.HttpUtility.JavaScriptStringEncode(alert.alert.Urgent) +
                                "\",\"unread\":\"" + Convert.ToInt32(alert.isclosed).ToString() + "\",\"position\":\"" +
                                System.Web.HttpUtility.JavaScriptStringEncode(alert.alert.Position) + "\",\"ticker\":\"" +
                                alert.alert.Ticker + "\",\"to_date\":\"" +
                                System.Web.HttpUtility.JavaScriptStringEncode(alert.alert.To_date) + "\"},");
                    }
    
                    res = res.TrimEnd(','); //trim right ","
                    res = "({\"historyCount\":" + alerts.Count.ToString() + ",\"historyContent\":[" + res + "]});";
    
                    dynamic variable = Browserwindow.Wb.InvokeScript("eval", new object[] { strVar3 });
                    variable(res);
    
                    return res;
                }
    
            }
