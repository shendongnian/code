        using (StreamWriter sw = new StreamWriter(@"D:\CYA\TestDuece.txt"))
        {
            sw.WriteLine("Name\t\tGender\t\tWeight\t\tHeight\t\tEye Color\t\tHair Color");
            using (StreamReader sr = new StreamReader(@"D:\CYA\Test.txt"))
            {
                string stringy;
                while ((stringy = sr.ReadLine()) != null)
                {
                    sw.WriteLine(stringy);
                }  
            }
        }
