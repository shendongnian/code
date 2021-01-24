    [XmlRoot("response")]
    public class Response
    {
        [XmlElement("version")]
        public string Version { get; set; }
        [XmlElement("termsofService")]
        public string TermsOfService { get; set; }
        [XmlElement("features")]
        public Features Features { get; set; }
        [XmlElement("forecast")]
        public Forecast Forecast { get; set; }
    }
    
    public class Features
    {
        [XmlElement("forecast")]
        public int Forecast { get; set; }
    }
    
    public class Forecast
    {
        [XmlElement("txt_forecast")]
        public TxtForecast TxtForecast { get; set; }
        [XmlElement("simpleforecast")]
        public SimpleForecast SimpleForecast { get; set; }
    }
    
    public class TxtForecast
    {
        [XmlElement("date")]
        public string Date { get; set; }
        [XmlArray("forecastdays")]
        [XmlArrayItem("forecastday")]
        public List<ForecastDay> ForecastDays { get; set; }
    }
    
    public class ForecastDay
    {
        [XmlElement("period")]
        public int Period { get; set; }
        [XmlElement("icon")]
        public string Icon { get; set; }
        [XmlElement("icon_url")]
        public string IconUrl { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("fcttext")]
        public string FctText { get; set; }
        [XmlElement("fcttext_metric")]
        public string FctTextMetric { get; set; }
        [XmlElement("pop")]
        public string Pop { get; set; }
    }
    
    
    public class SimpleForecast
    {
        [XmlArray("forecastdays")]
        [XmlArrayItem("forecastday")]
        public List<ForecastDay2> ForecastDays { get; set; }
    }
    
    public class ForecastDay2
    {
        [XmlElement("date")]
        public Date Date { get; set; }
        [XmlElement("period")]
        public int Period { get; set; }
        [XmlElement("high")]
        public High High { get; set; }
        [XmlElement("low")]
        public Low Low { get; set; }
        [XmlElement("conditions")]
        public string Conditions { get; set; }
        [XmlElement("icon")]
        public string Icon { get; set; }
        [XmlElement("icon_url")]
        public string IconUrl { get; set; }
        [XmlElement("skyicon")]
        public string SkyIcon { get; set; }
        [XmlElement("pop")]
        public int Pop { get; set; }
        [XmlElement("qpf_allday")]
        public QpfAllday QpfAllDay { get; set; }
        [XmlElement("qpf_day")]
        public QpfDay QpfDay { get; set; }
        [XmlElement("qpf_night")]
        public QpfNight QpfNight { get; set; }
        [XmlElement("snow_allday")]
        public SnowAllday SnowAllday { get; set; }
        [XmlElement("snow_day")]
        public SnowDay SnowDay { get; set; }
        [XmlElement("snow_night")]
        public SnowNight SnowNight { get; set; }
        [XmlElement("maxwind")]
        public MaxWind MaxWind { get; set; }
        [XmlElement("avewind")]
        public AveWind AveWind { get; set; }
        [XmlElement("avehumidity")]
        public int AveHumidity { get; set; }
        [XmlElement("maxhumidity")]
        public int MaxHumidity { get; set; }
        [XmlElement("minhumidity")]
        public int MinHumidity { get; set; }
    }
    
    public class Date
    {
        [XmlElement("epoch")]
        public string Epoch { get; set; }
        [XmlElement("pretty")]
        public string Pretty { get; set; }
        [XmlElement("day")]
        public int Day { get; set; }
        [XmlElement("month")]
        public int Month { get; set; }
        [XmlElement("year")]
        public int Year { get; set; }
        [XmlElement("yday")]
        public int Yesterday { get; set; }
        [XmlElement("hour")]
        public int Hour { get; set; }
        [XmlElement("min")]
        public string Min { get; set; }
        [XmlElement("sec")]
        public int Sec { get; set; }
        [XmlElement("isdst")]
        public string Isdst { get; set; }
        [XmlElement("monthname")]
        public string MonthName { get; set; }
        [XmlElement("monthname_short")]
        public string MonthNameShort { get; set; }
        [XmlElement("weekday_short")]
        public string WeekdayShort { get; set; }
        [XmlElement("weekday")]
        public string Weekday { get; set; }
        [XmlElement("ampm")]
        public string AmPM { get; set; }
        [XmlElement("tz_short")]
        public string TzShort { get; set; }
        [XmlElement("tz_long")]
        public string TzLong { get; set; }
    }
    
    public class High
    {
        [XmlElement("fahrenheit")]
        public string Fahrenheit { get; set; }
        [XmlElement("celsius")]
        public string Celsius { get; set; }
    }
    
    public class Low
    {
        [XmlElement("fahrenheit")]
        public string Fahrenheit { get; set; }
        [XmlElement("celsius")]
        public string Celsius { get; set; }
    }
    
    public class QpfAllday
    {
        [XmlElement("@in")]
        public double Inches { get; set; }
        [XmlElement("mm")]
        public int Milimeters { get; set; }
    }
    
    public class QpfDay
    {
        [XmlElement("@in")]
        public double Inches { get; set; }
        [XmlElement("mm")]
        public int Milimeters { get; set; }
    }
    
    public class QpfNight
    {
        [XmlElement("@in")]
        public double Inches { get; set; }
        [XmlElement("mm")]
        public int Milimeters { get; set; }
    }
    
    public class SnowAllday
    {
        [XmlElement("@in")]
        public double Inches { get; set; }
        [XmlElement("cm")]
        public double Centimeters { get; set; }
    }
    
    public class SnowDay
    {
        [XmlElement("@in")]
        public double Inches { get; set; }
        [XmlElement("cm")]
        public double Centimeters { get; set; }
    }
    
    public class SnowNight
    {
        [XmlElement("@in")]
        public double Inches { get; set; }
        [XmlElement("cm")]
        public double Centimeters { get; set; }
    }
    
    public class MaxWind
    {
        [XmlElement("mph")]
        public int Mph { get; set; }
        [XmlElement("kph")]
        public int Kph { get; set; }
        [XmlElement("dir")]
        public string Direction { get; set; }
        [XmlElement("degrees")]
        public int Degrees { get; set; }
    }
    
    public class AveWind
    {
        [XmlElement("mph")]
        public int Mph { get; set; }
        [XmlElement("kph")]
        public int Kph { get; set; }
        [XmlElement("dir")]
        public string Direction { get; set; }
        [XmlElement("degrees")]
        public int Degrees { get; set; }
    }
