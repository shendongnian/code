    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    public class OffsetedDatePicker : DatePicker
    {
    	public new DateTimeOffset? SelectedDate
    	{
    		get { return (DateTimeOffset)GetValue(SelectedDateOffProperty); }
    		set { SetValue(SelectedDateOffProperty, value); }
    	}
    
    	public static readonly DependencyProperty SelectedDateOffProperty =
    		DependencyProperty.Register(nameof(SelectedDate), typeof(DateTimeOffset?), typeof(OffsetedDatePicker), new PropertyMetadata(null, SelectedDateOffChanged));
    
    	private static void SelectedDateOffChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    	{
    		var odp = d as OffsetedDatePicker;
    		if (odp==null) { return; }			
    		(d as DatePicker).SelectedDate = odp.SelectedDate.HasValue ? odp.SelectedDate.Value.Date : (DateTime?)null;
    	}
    	
    	public OffsetedDatePicker()
    	{
    		SelectedDateChanged += OffsetedDatePicker_SelectedDateChanged;
    	}
    
    	private void OffsetedDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
    	{
    		DateTime? newDate = null;
    		if (e.AddedItems.Count > 0)
    		{
    			newDate = (DateTime)e.AddedItems[0];
    		}
    		SetValue(SelectedDateOffProperty, newDate.HasValue ? new DateTimeOffset(newDate.Value) : (DateTimeOffset?)null);
    	}
    }
