	public string[][] userArray;
	public string[][] StudentArray;
    public void UserSorting(string[][] userArray)
    {
        List<string[]> studentList = new List<string[]>();
        //for each row in user array
        for (int userIndex = 0; userIndex < userArray.Length; userIndex++)
        {
            //Compares the stored account type to STUDENT
            if (userArray[userIndex] != null && userArray[userIndex].Length > 5 && userArray[userIndex][5] == "STUDENT")
            {
                string[] userAttributes = userArray[userIndex];
                //for each user value copy into the new array
                string[] studentAttributes = new string[userAttributes.Length];
                for (int attributeIndex = 0; attributeIndex < userAttributes.Length; attributeIndex++)
                {
                    studentAttributes[attributeIndex] = userAttributes[attributeIndex];
                    Debug.Log(studentAttributes[attributeIndex]);
                }
                studentList.Add(studentAttributes);
            }
        }
        StudentArray = studentList.ToArray();
    }
