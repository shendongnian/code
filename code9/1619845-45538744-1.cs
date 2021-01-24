     public virtual IList<ClassroomDetail> GetLatestClassroomDetail(string classroom)
        {
            var query = _classroomDetailRepository.Table
                .Where(z => z.Classroom == classroom)
                .GroupBy(x => x.StudentName)                
                .Select(x => x.OrderByDescending(y => y.GradeDate).FirstOrDefault());
            var result = new List<BunkerPriceDetail>(query);
            return result;
        }
