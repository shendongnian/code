    SqlParameter u = new SqlParameter("@UserId", assignments.UserId);
    SqlParameter a = new SqlParameter("@AdmissionId", AdmissionId);
    SqlParameter pr = new SqlParameter("@PracticeId", assignments.PracticeId);
    await _context.Database.ExecuteSqlCommandAsync("EXEC AdmissionConsultEndCurrentAndPending @PracticeId, @UserId, @AdmissionId",
                                        parameters: new[] { a, u, pr });
