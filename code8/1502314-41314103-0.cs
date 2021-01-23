    public class Job
    {
        .........
        DateTime DatePerformed {get; set;}
        .........
    }
    void SelectFromDateRange ()
    {
        DateTime fromDate;
        DateTime toDate;
       
        var jobsBetweenDates = await _connection.Table<Job>().Where(job => (
				job.DatePerformed > startDate && job.DatePerformed < endDate)).ToListAsync();
	    _jobs = new ObservableCollection<Job>(jobsBetweenDates);
	    JobListView.ItemsSource = _jobs;
    }
    
