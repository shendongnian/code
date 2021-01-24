	public T BuildQuery<T>(Expression<Func<ScheduleItemAttendee, AttendeeService, T>> selector)
	{
		return
			from ScheduleItemAttendee SIA in context.ScheduleItemAttendees
			join AttendeeService AS in context.AttendeeServices on SIA.Id equals AS.AttendeeId into x
			from Att in x.DefaultIfEmpty()
			where (Att == null || !Att.IsDeleted)
				&& !(SIA == null || SIA.IsDeleted)
				&& ((string.IsNullOrEmpty(criteria.Keyword))
					|| (SIA.Individual.FullNameAr.Trim().ToLower().Contains(criteria.Keyword)
					|| SIA.Individual.FullNameEn.Trim().ToLower().Contains(criteria.Keyword))))
			select selector(SIA, Att);
	}
