    public static void LoadArray()
    {
        StreamReader studentInfoStreamReader = new StreamReader("LittleRecord2.txt");
        for (counter = 0; counter < 21; counter++)
        {
            if (studentInfoStreamReader.Peek() != -1) // CHECK TO SEE IF END OF FILE
            {
                var splitLine = studentInfoStreamReader.ReadLine().Split(',');
                studentName[counter] = splitLine[0];
                studentGrade[counter] = splitLine[1];
            }
        }
        studentInfoStreamReader.Close(); 
    }
