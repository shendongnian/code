    public void listStudentData()
    {
        String fname ="", lname="", add="", city="", country="", post="", id="", grd = "";
        String[,] index = { { "First name: ", "Last Name: ", "Address: ", "City: ", "Country: ", "Postcode: ", "StudentID: ", "Grade: " }, { fname, lname, add, city, country, post, id, grd }, };
        for (int i = 0; i < studentList.Count; i++)
        {
            index[1,0] = studentList[i].firstName.ToString();
            index[1,1] = studentList[i].lastName.ToString();
            index[1,2] = studentList[i].address.ToString();
            index[1,3] = studentList[i].city.ToString();
            index[1,4] = studentList[i].country.ToString();
            index[1,5] = studentList[i].postcode.ToString();
            index[1,6] = studentList[i].StudentID.ToString();
            index[1,7] = studentList[i].grade.ToString();
            
            for (int j = 0; j < 8; j++)
            {
                Console.WriteLine(index[0, i] + index[1,j]);
            }        
        }
        Console.WriteLine("");
    }
