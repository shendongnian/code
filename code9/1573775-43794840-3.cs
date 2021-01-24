    List<double> duplicatedVolumes = new List<double>();
    for (int i = 0; i < boxArray1.Length; i++) //Loop through the first array
    {
        for (int j= 0; j < boxArray2.Length; j++) //Loop through the second array
        {
            var volumeA = boxArray1[i].Length * boxArray1[i].Width * boxArray1[i].Height; //Compute box A volume
            var volumeB = boxArray2[j].Length * boxArray2[j].Width * boxArray2[j].Height; //Compute box B volume
            if(volumeA - double.Epsilon < volumeB && volumeA + double.Epsilon > volumeB)
            {
              //Check if the volumes are equal, note the use of the Epsilon, that's because 
              //double values aren't exact and we must have that into account. double.Epsilon 
              //is the smallest (not lowest) value a double can store so it's very 
              //thightened, you can increase this value if you have errors.
            
                duplicatedVolumes.Add(volumeA);
                break;
            }
            //No, continue loop
        }
    } 
