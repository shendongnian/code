    var parameters = new List<SqlParameter>
                     {
                         new SqlParameter("@PracticeId", assignmentsPracticeId),
                         new SqlParameter("@UserId", assignmentsUserId),
                         new SqlParameter("@AdmissionId", AdmissionId)
                     };
    await _context.Database.ExecuteSqlCommandAsync(
           "EXEC AdmissionConsultEndCurrentAndPending @PracticeId, @UserId, @AdmissionId", 
           parameters.ToArray());
