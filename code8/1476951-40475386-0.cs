    //data patch
    string[] tekst = File.ReadAllLines(@"C:\zoo.txt");
    //full of array - you allready have a string[], no need for a new one
    //string[] tablica = tekst;
    for(int s=0;s<tekst.Length;s++)
    {
        Console.WriteLine(tekst[s]);
    }
    //----------------Show all of array---------------------------//
    //----------------Giv a number of column-----------------////
    // try to use names with some meaning for variables, for example intead os "a" use "column" for the column 
    Console.WriteLine("Podaj kolumne");
    int column = Convert.ToInt32(Console.ReadLine());
    // you result for zeros in a given column
    int suma = 0;
    // for each line in your string[]
    foreach ( string line in tekst )
    {
        // get the line separated by comas
        string[] lineColumns = line.Split(',');
        // check if that column is a zero, remember index is base 0
        if ( lineColumns[column-1] == "0" )
            suma++;
    }
    Console.WriteLine(suma);
