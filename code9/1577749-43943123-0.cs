    public class SSiJob
    {
        public int id { get; set; }
        public string path { get; set; }
        public bool matched { get; set; }
    }
            List<SSiJob> jobs = new List<SSiJob>();
            using (StreamReader sr = new StreamReader(@"D:\CYA\Test2.txt"))
            {
                string stringy;
                while ((stringy = sr.ReadLine()) != null)
                {
                    string[] words = stringy.TrimStart().Split(' ');
                    if (words[0] == ">%SSiJobFileRef:")
                    {
                       jobs.Add(new SSiJob { id = Convert.ToInt32(words[1]), path = words[2] });
                    }
                    else if (words[0] == ">%SSiJobPage:")
                    {
                        var check = jobs.Where(a => a.id == Convert.ToInt32(words[1])).FirstOrDefault();
                        if(check != null)
                        {
                            check.matched= true;
                        }
                    }
                }
                jobs.RemoveAll(a => a.matched == false);
            }
