     public void AddJobAnnouncement(JobAnnouncement jobAnnouncemnet)
            {
    _jobAnnouncement.Content = jobAnnouncemnet.Content; //ok
    _jobAnnouncement.CompanyId = jobAnnouncemnet.CompanyId; //ok
     // it will by ok now
    jobAnnouncement.Skills = new List<Skill>();
                foreach (var skill in jobAnnouncemnet.Skills)
                {
                    _jobAnnouncement.Skills.Add(db.Skills.Find(skill.Id));
                }
    }
