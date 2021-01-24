            public bool IsCourseExist(string courseID)
            {
                const int columnCourseID = 0;
                foreach(DataRow row in gridView.Rows)
                {
                    if(row[columnCourseID].ToString() == courseID)
                        return true;
                }
                return false;
            }
