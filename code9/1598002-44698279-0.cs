    public class YahooJson2CsvController : ApiController
    {
        public HttpResponseMessage GetJson2Csv(string code, string range, string interval)
        {
            try
            {
                AppendLog("============================================");
                AppendLog("Starting to download { CODE: " + code + "; RANGE: " + range + "; INTERVAL: " + interval + " }");
    
                var csvBasePath = HttpContext.Current.Server.MapPath("~/YahooCSV/");
                var objCsvBasePath = new DirectoryInfo(csvBasePath);
                if (!objCsvBasePath.Exists) { objCsvBasePath.Create(); AppendLog("YahooCSV folder created"); }
    
                var csvYesterdayPath = HttpContext.Current.Server.MapPath("~/YahooCSV/" + DateTime.Now.AddDays(-1).ToString("MMddyyyy") + "/");
                var objCsvYesterdayPath = new DirectoryInfo(csvYesterdayPath);
                if (objCsvYesterdayPath.Exists) { objCsvYesterdayPath.Delete(true); AppendLog("Deleted yesterday's download folder"); }
    
                var csvTodayPath = HttpContext.Current.Server.MapPath("~/YahooCSV/" + DateTime.Now.ToString("MMddyyyy") + "/");
                var objCsvTodayPath = new DirectoryInfo(csvTodayPath);
                if (!objCsvTodayPath.Exists) { objCsvTodayPath.Create(); AppendLog("Created today's download folder"); }
    
                if (string.IsNullOrEmpty(code.Trim())) return new HttpResponseMessage(HttpStatusCode.BadRequest);
                if (string.IsNullOrEmpty(range.Trim())) return new HttpResponseMessage(HttpStatusCode.BadRequest);
                if (string.IsNullOrEmpty(interval.Trim())) return new HttpResponseMessage(HttpStatusCode.BadRequest);
    
                var wc = new WebClient();
                var url = ConfigurationManager.AppSettings["YahooURL"].Replace("@C", code).Replace("@R", range).Replace("@I", interval);
                var str = wc.DownloadString(url);
                if (string.IsNullOrEmpty(str)) { AppendLog("No content for current code"); return new HttpResponseMessage(HttpStatusCode.NoContent); }
                AppendLog("Downloaded content for current code");
    
                var data = JsonConvert.DeserializeObject<RootObject>(str);
                if (data == null) { AppendLog("Empty deserialized object"); return new HttpResponseMessage(HttpStatusCode.NoContent); }
    
                var result = new List<string>();
                var quotesInfo = data.chart.result.First();
    
                for (var i = 0; i < quotesInfo.timestamp.Count; i++)
                {
                    if (quotesInfo.meta.firstTradeDate != null && quotesInfo.timestamp[i] < quotesInfo.meta.firstTradeDate) continue;
    
                    var quotesStr = new List<string>();
                    var quoteData = quotesInfo.indicators.quote.First();
                    var quoteAdjData = quotesInfo.indicators.unadjclose.First();
    
                    quotesStr.Add(UnixTimeStampToDateTime(quotesInfo.timestamp[i]).ToString(CultureInfo.InvariantCulture));
                    quotesStr.Add(quoteData.open[i].HasValue ? quoteData.open[i].ToString() : string.Empty);
                    quotesStr.Add(quoteData.high[i].HasValue ? quoteData.high[i].ToString() : string.Empty);
                    quotesStr.Add(quoteData.low[i].HasValue ? quoteData.low[i].ToString() : string.Empty);
                    quotesStr.Add(quoteData.close[i].HasValue ? quoteData.close[i].ToString() : string.Empty);
                    quotesStr.Add(quoteData.volume[i] != null ? quoteData.volume[i].ToString() : string.Empty);
                    quotesStr.Add(quoteAdjData.unadjclose[i].HasValue ? quoteAdjData.unadjclose[i].ToString() : string.Empty);
                    result.Add(string.Join(",", quotesStr));
                }
                if (result.Count <= 0) { AppendLog("No valid content to deserialize"); return new HttpResponseMessage(HttpStatusCode.NoContent); }
                AppendLog("Deserialized successful");
    
                var tempFileName = code + "_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".csv";
                File.WriteAllLines(csvTodayPath + tempFileName, result);
                AppendLog("Created temp csv file to download");
    
                var memStream = new MemoryStream();
    
                using (var fileStream = File.OpenRead(csvTodayPath + tempFileName))
                {
                    memStream.SetLength(fileStream.Length);
                    fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);
                }
    
                var csvResult = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StreamContent(memStream) };
                csvResult.Content.Headers.ContentType = new MediaTypeHeaderValue("text/csv");
                csvResult.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = code + ".csv" };
                AppendLog("Downloaded: " + tempFileName);
                return csvResult;
            }
            catch (Exception ex)
            {
                AppendLog(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
        }
    
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToUniversalTime();
            return dtDateTime;
        }
    
        public static void AppendLog(string Log)
        {
            StreamWriter sw = File.AppendText(System.AppDomain.CurrentDomain.BaseDirectory + "Log.log");
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " :: " + Log);
            sw.Close();
            sw.Dispose();
        }
    }
    
    public class Pre
    {
        public string timezone { get; set; }
        public int end { get; set; }
        public int start { get; set; }
        public int gmtoffset { get; set; }
    }
    
    public class Regular
    {
        public string timezone { get; set; }
        public int end { get; set; }
        public int start { get; set; }
        public int gmtoffset { get; set; }
    }
    
    public class Post
    {
        public string timezone { get; set; }
        public int end { get; set; }
        public int start { get; set; }
        public int gmtoffset { get; set; }
    }
    
    public class CurrentTradingPeriod
    {
        public Pre pre { get; set; }
        public Regular regular { get; set; }
        public Post post { get; set; }
    }
    
    public class Meta
    {
        public string currency { get; set; }
        public string symbol { get; set; }
        public string exchangeName { get; set; }
        public string instrumentType { get; set; }
        public int? firstTradeDate { get; set; }
        public int gmtoffset { get; set; }
        public string timezone { get; set; }
        public string exchangeTimezoneName { get; set; }
        public CurrentTradingPeriod currentTradingPeriod { get; set; }
        public string dataGranularity { get; set; }
        public List<string> validRanges { get; set; }
    }
    
    public class Quote
    {
        public List<object> volume { get; set; }
        public List<double?> low { get; set; }
        public List<double?> high { get; set; }
        public List<double?> close { get; set; }
        public List<double?> open { get; set; }
    }
    
    public class Unadjclose
    {
        public List<double?> unadjclose { get; set; }
    }
    
    public class Unadjquote
    {
        public List<double?> unadjopen { get; set; }
        public List<double?> unadjclose { get; set; }
        public List<double?> unadjhigh { get; set; }
        public List<double?> unadjlow { get; set; }
    }
    
    public class Indicators
    {
        public List<Quote> quote { get; set; }
        public List<Unadjclose> unadjclose { get; set; }
        public List<Unadjquote> unadjquote { get; set; }
    }
    
    public class Result
    {
        public Meta meta { get; set; }
        public List<int> timestamp { get; set; }
        public Indicators indicators { get; set; }
    }
    
    public class Chart
    {
        public List<Result> result { get; set; }
        public object error { get; set; }
    }
    
    public class RootObject
    {
        public Chart chart { get; set; }
    }
