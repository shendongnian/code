            int intCounter = 0;
            foreach (var item5 in StudentsByTeacherName)
                {
                    intCounter++;
                    if (StudentsByTeacherName.ContainsKey(item5.Key))
                    {
                        StudentsByTeacherName[intCounter.ToString()] = new List<string>(new string[] { "hello", "world" });
                    }
                    else
                    {
                        StudentsByTeacherName.Add(item4.Value,StudentName);
                    }
                }
