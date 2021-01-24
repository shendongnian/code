    var activeEvaluationrounds = from r in _context.EvaluationRounds.Include(e => e.EvaluationRoundProject.ProjectGroups.Select(pg => pg.Persons)).Include(e => e.Evaluations)
        join g in _context.ProjectGroups on r.ProjectId equals g.ProjectId
        join m in _context.ProjectGroupMembers on g.ProjectGroupId equals m.GroupId
        where m.PersonId == studentId && r.EvaluationRoundStartTime < DateTime.Now && r.EvaluationRoundEndTime > DateTime.Now
        select new EvaluationRoundDto
        {
            EvaluationRoundId = r.EvaluationRoundId,
            ProjectId = r.ProjectId
            //etc.
        };
