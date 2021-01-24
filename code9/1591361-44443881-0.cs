    class Program
    {
        private static List<string> getListCountry()
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\flags");
            FileInfo[] files=d.GetFiles("*.png");
            List<string> lstNames=new List<string>();
            foreach(var file in files)
                lstNames.Add(file.Name.Replace(".png",String.Empty));
            return lstNames;
        }
        
        private static List<string> getNameRandom(string name, List<string> lstNames)
        {
            HashSet<string> myHashSet = new HashSet<string>();
            myHashSet.Add(name);
            while(myHashSet.Count<4)
            {
                myHashSet.Add(lstNames.OrderBy(s => Guid.NewGuid()).First());
                
            }
            return myHashSet.OrderBy(s => Guid.NewGuid()).ToList();
        }
        
        private static void generateQuery()
        {
            List<string> lstQuery = new List<string>();
            List<string> lstCountryName = getListCountry();
            string query = String.Empty;
            foreach(var name in lstCountryName)
            {
                List<string> answerList=getNameRandom(name,lstCountryName);
                query =     "INSERT INTO Question(Image,AnswerA,AnswerB,AnswerC,AnswerD,CorrectAnswer)"
                        +   $"VALUES( \'{name}\',\"{answerList[0]}\",\"{answerList[1]}\",\"{answerList[2]}\",\"{answerList[3]}\",\"{name}\");";
                
            }
        }
        
        static async void Main(string[] args)
        {
        }
    }
}
