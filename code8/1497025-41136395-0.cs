	List<MeetingVM> students = (
		from s in db.Meetings 
		where MeetingIsActive == null || s.IsActive == MeetingIsActive 
		where MeetingStat == null || MeetingStat == 5 ? (DateTime.UtcNow >= s.MeetingStartTime && DateTime.UtcNow <= s.MeetingStopTime) : s.Status== MeetingStat
		where StartDate == null || (s.MeetingStartTime >= StartDate && s.MeetingStartTime <= EndDate) 
		where s.Status!=4 
		orderby s.MeetingStartTime ascending 
		select new MeetingVM
		{
			MeetingStartTime = s.MeetingStartTime,
			MeetingStopTime = s.MeetingStopTime,
			Alias = s.Alias,
			MeetingSubject = s.MeetingSubject,
			UserId = s.UserId,
			Status=s.Status
		}).ToList();
