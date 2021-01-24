    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;
    					
    public class Program
    {
    	public static void Main( string[] args )
    	{
    		var periods = new List<Period> {
    			new Period( "1", Days.Workdays, TimeSpan.FromHours(0), TimeSpan.FromHours(7) ),
    			new Period( "2", Days.Workdays, TimeSpan.FromHours(7), TimeSpan.FromHours(20) ),
    			new Period( "3", Days.Workdays, TimeSpan.FromHours(20), TimeSpan.FromHours(22) ),
    			new Period( "4", Days.Workdays, TimeSpan.FromHours(22), TimeSpan.FromHours(24) ),
    			new Period( "5", Days.Weekend, TimeSpan.FromHours(0), TimeSpan.FromHours(7) ),
    			new Period( "6", Days.Weekend, TimeSpan.FromHours(7), TimeSpan.FromHours(22) ),
    			new Period( "7", Days.Weekend, TimeSpan.FromHours(22), TimeSpan.FromHours(24) ),
    			new Period( "8", Days.Holiday, TimeSpan.FromHours(0), TimeSpan.FromHours(24) ),
    		};
    		var holidays = new List<DateTime> {
    			new DateTime( 2017, 1, 1 ),
    			new DateTime( 2017, 1, 3 ),
    			new DateTime( 2017, 1, 6 ),
    		};
    		
    		var sc = new ShiftCalculator( periods, holidays );
    		
    		var shiftperiods = sc.GetShiftPeriods( new DateTime( 2016, 12, 31, 22, 00, 00 ), new DateTime( 2017, 01, 07, 08, 00, 00 ) ).ToList();
    		
    		foreach ( var sp in shiftperiods )
    		{
    			Console.WriteLine( "{0} - {1} - {2} - {3:00.00}h", sp.Period.Name, sp.Period.Days, sp.Start, sp.Duration.TotalHours );
    		}
    		
    	}
    }
    
    [Flags]
    enum Days : byte
    {
    	Sunday = 1,
    	Monday = 2,
    	Tuesday = 4,
    	Wednesday = 8,
    	Thursday = 16,
    	Friday = 32,
    	Saturday = 64,
    	Holiday = 128,
    	
    	Workdays = Monday | Tuesday | Wednesday | Thursday | Friday,
    	Weekend = Saturday | Sunday,
    }
    
    [DebuggerDisplay("{Name}: {Days} ({Start}-{End})")]
    class Period
    {
    	public Period( string name, Days days, TimeSpan start, TimeSpan end )
    	{
    		if ( days.HasFlag( Days.Holiday ) && days != Days.Holiday )
    			throw new ArgumentException( "days" );
    		
    		if ( start > end )
    			throw new ArgumentException( "end" );
    		
    		Name = name;
    		Days = days;
    		Start = start;
    		End = end;
    	}
    	
    	public string Name { get; private set; }
    	public Days Days { get; private set; }
    	public TimeSpan Start { get; private set; }
    	public TimeSpan End { get; private set; }
    }
    
    class ShiftPeriod
    {
    	public Period Period { get; set; }
    	public DateTime Start { get; set; }
    	public TimeSpan Duration { get; set; }
    }
    
    class ShiftCalculator
    {
    	private readonly List<Period> _periods;
    	private readonly List<DateTime> _holidays;
    	
    	public ShiftCalculator( IEnumerable<Period> periods, IEnumerable<DateTime> holidays )
    	{
    		_periods = periods.ToList();
    		_holidays = holidays.Select( e => e.Date ).ToList();
    	}
    	
    	public IEnumerable<ShiftPeriod> GetShiftPeriods( DateTime start, DateTime end )
    	{
    		if ( start > end ) throw new ArgumentException( "end" );
    		
    		var current = start;
    		
    		while ( current < end )
    		{
    			var period = GetPeriodByDateTime( current );
    			
    			var next = current.Date + period.End;
    			
    			if ( next > end )
    			{
    				next = end;
    			}
    			
    			yield return new ShiftPeriod
    			{
    				Period = period,
    				Start = current,
    				Duration = next - current,
    			};
    			
    			current = next;
    		}
    		
    	}
    	
    	private Days GetDayFromDateTime( DateTime datetime )
    	{
    		Days day;
    		if ( _holidays.Contains( datetime.Date ) )
    		{
    			day = Days.Holiday;
    		}
    		else
    		{
    			switch ( datetime.DayOfWeek )
    			{
    				case DayOfWeek.Sunday:
    				day = Days.Sunday;
    				break;
    				case DayOfWeek.Monday:
    				day = Days.Monday;
    				break;
    				case DayOfWeek.Tuesday:
    				day = Days.Tuesday;
    				break;
    				case DayOfWeek.Wednesday:
    				day = Days.Wednesday;
    				break;
    				case DayOfWeek.Thursday:
    				day = Days.Thursday;
    				break;
    				case DayOfWeek.Friday:
    				day = Days.Friday;
    				break;
    				case DayOfWeek.Saturday:
    				day = Days.Saturday;
    				break;
    				default:
    				throw new InvalidOperationException();
    			}
    		}
    		return day;
    	}
    	
    	private Period GetPeriodByDateTime( DateTime datetime )
    	{
    		var day = GetDayFromDateTime( datetime );
    		var timeOfDay = datetime.TimeOfDay;
    		var period = _periods.Where(
    			e => e.Days.HasFlag( day ) && e.Start <= timeOfDay && e.End > timeOfDay )
    			.FirstOrDefault();
    		if ( period == null )
    		{
    			throw new InvalidOperationException();
    		}
    		return period;
    	}
    }
