    using System;
    using NodaTime;
    using NodaTime.Text;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string _QsDateTime = "12.11.2016 21:30";
    		var _CountryZone = DateTimeZoneProviders.Tzdb["Europe/Istanbul"];
    		var _DatePattern = LocalDateTimePattern.CreateWithCurrentCulture("dd.MM.yyyy HH:mm");
    		var _LocalTime = _DatePattern.Parse(_QsDateTime).Value;
    		var _LocalTime2TargetZoneTime = _LocalTime.InZoneStrictly(_CountryZone);
    		var _TargetZone2Utc = _LocalTime2TargetZoneTime.WithZone(DateTimeZone.Utc).ToDateTimeUtc();
    		_QsDateTime = _TargetZone2Utc.ToString("yyyy-MM-dd HH:mm:ss");
    		Console.WriteLine(_QsDateTime);
    	}
    }
