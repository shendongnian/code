    var grouped_by_competition = all_events
    .GroupBy(e => e.Competition)
    .Select(x => {{
       dynamic ret=new System.Dynamic.ExpandoObject();
       ret.Competition=x.Key;
       ret.Items=x;
       return ret;
    } );
    foreach( var group in grouped_by_competition )
    {
        group.Competition.DoSomething();
    }
