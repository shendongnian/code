     CourseVideo video = Repository.GetCourseVideoStream(courseId);
            var bytesinfile = new byte[video.VideoStream.Length];
            video.VideoStream.Read(bytesinfile, 0, (int)video.VideoStream.Length);
            byte[] buffer = new byte[4096];
            ControllerContext.HttpContext.Response.ContentType = "video/x-ms-wmv";
            ControllerContext.HttpContext.Response.AppendHeader("content-length", video.VideoStream.Length.ToString());
            video.VideoStream.Seek(0, SeekOrigin.Begin);
            ControllerContext.HttpContext.Response.BinaryWrite(bytesinfile);
            ControllerContext.HttpContext.Response.End();
