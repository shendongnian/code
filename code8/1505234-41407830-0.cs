    var result = from course in DbCourses
                 join courseTutionCenter in DbCourseTutionCenter
                 on course.Id equals courseTutionCenter.CourseId 
                 join courseStudent in DbCourseStudent
                 on courseStudent.Course_TutionCenter_Id equals courseTutionCenter.TutionCenterId  
                 group by new { course.Id, course.Name } into gr
                 select new
                 {
                     CourseId = gr.Key.Id,
                     CourseName = gr.Key.Name,
                     TutionCenters = gr.GroupBy(x=>x.courseStudent.Course_TutionCenter_Id).Count(),
                     Students = gr.GroupBy(x=>x.courseStudent.Id).Count()
                 };
                 
 
                 
