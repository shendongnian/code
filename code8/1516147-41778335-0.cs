    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    using NUnit.Framework;
    
    namespace TIPS.UnitTest
    {
    public class EventInfo
    {
    	public DateTime Date;
    	public EventSource EventSource;
    	public List<EventSource> AdditionalEventSources; // Left null if no additional sources
    }
    
    public abstract class EventSource
    {
    	public string Name
    	{
    		get { return GetType().Name; }
    	}
    
    	public abstract IEnumerable<DateTime> RecurringDates();
    }
    
    public interface IEventInfoGenerator
    {
    	IEnumerable<EventInfo> GenerateEvents(List<EventSource> eventSources);
    }
    
    public class MyAnswerEventInfoGenerator: IEventInfoGenerator
    {
    	public IEnumerable<EventInfo> GenerateEvents(List<EventSource> eventSources)
    	{
    		// Combine the Event Sources and their DateEnumerators ignoring any without Dates to return
    		var sourceEnumerators = eventSources
    			.Select(es =>
    				        new
    					        {
    						        Source = es,
    						        DateEnumerator = es.RecurringDates().GetEnumerator()
    					        })
    			.Where(e => e.DateEnumerator.MoveNext())
    			.ToList();
    
    		// Keep going until there is nothing left
    		while (sourceEnumerators.Any())
    		{
    			// Find the earliest date
    			var earliestSource = sourceEnumerators.OrderBy(se => se.DateEnumerator.Current).First();
    
    			// Prepare the EventInfo
    			var eventInfo = new EventInfo
    				                {
    					                Date = earliestSource.DateEnumerator.Current,
    					                EventSource = earliestSource.Source
    				                };
    
    			// Remove the EventSource if it has no more Dates
    			if (!earliestSource.DateEnumerator.MoveNext())
    			{
    				sourceEnumerators.Remove(earliestSource);
    			}
    
    			// Quick check to see if there are other EventSources with the same date (no need to create a list if not necessary
    			if (sourceEnumerators.Any(se => se != earliestSource && se.DateEnumerator.Current == eventInfo.Date))
    			{
    				// Yes, there are so create a list for them
    				eventInfo.AdditionalEventSources = new List<EventSource>();
    
    				// Go through each 
    				foreach (var additionalSourceEnumerator in sourceEnumerators.Where(se => se != earliestSource && se.DateEnumerator.Current == eventInfo.Date).ToArray())
    				{
    					// Add it to the EventInfo list
    					eventInfo.AdditionalEventSources.Add(additionalSourceEnumerator.Source);
    
    					// And remove them if they are spent
    					if (!additionalSourceEnumerator.DateEnumerator.MoveNext())
    					{
    						sourceEnumerators.Remove(additionalSourceEnumerator);
    					}
    				}
    			}
    
    			yield return eventInfo;
    		}
    	}
    }
    
    
    [TestFixture]
    public class RecurrenceTests
    {
    	static IEnumerable<EventSource> CreateTestEventSources()
    	{
    		yield return new EventSource1();
    		yield return new EventSource2();
    		yield return new EventSource3();
    		yield return new EmptyEventSource();
    	}
    
    	static void TestStackoverAnswer(IEventInfoGenerator answer)
    	{
    		var testEventSources = CreateTestEventSources().ToList();
    
    		foreach (var eventInfo in answer.GenerateEvents(testEventSources))
    		{
    			Debug.Write($"{eventInfo.Date} - {eventInfo.EventSource.Name}");
    
    			if (eventInfo.AdditionalEventSources != null)
    			{
    				Debug.Write(", " + string.Join(", ", eventInfo.AdditionalEventSources.Select(ev => ev.Name)));
    			}
    
    			Debug.WriteLine(string.Empty);
    		}
    	}
    
    	[Test]
    	public void TestMyGo()
    	{
    		TestStackoverAnswer(new MyAnswerEventInfoGenerator());
    	}
    }
    
    public class EventSource1: EventSource
    {
    	public override IEnumerable<DateTime> RecurringDates()
    	{
    		yield return new DateTime(2017, 1, 1);
    		yield return new DateTime(2017, 2, 1);
    		yield return new DateTime(2017, 3, 1);
    		yield return new DateTime(2017, 4, 1);
    		yield return new DateTime(2017, 5, 1);
    		yield return new DateTime(2017, 6, 1);
    		yield return new DateTime(2017, 7, 1);
    	}
    }
    
    public class EventSource2: EventSource
    {
    	public override IEnumerable<DateTime> RecurringDates()
    	{
    		yield return new DateTime(2017, 3, 31);
    		yield return new DateTime(2017, 6, 30);
    		yield return new DateTime(2017, 9, 30);
    		yield return new DateTime(2017, 12, 31);
    	}
    }
    
    public class EventSource3: EventSource
    {
    	public override IEnumerable<DateTime> RecurringDates()
    	{
    		yield return new DateTime(2017, 12, 31);
    		yield return new DateTime(2018, 12, 31);
    		yield return new DateTime(2019, 12, 31);
    	}
    }
    
    public class EmptyEventSource: EventSource
    {
    	public override IEnumerable<DateTime> RecurringDates()
    	{
    		yield break;
    	}
    }
