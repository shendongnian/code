    public static void SortArray(FileData[] fileData)
    {
        bool swap;
        do
        {
            swap = false;
            for (int index = 0; index < (fileData.Length - 1); index++)
            {
                if (fileData[index].File1Value > fileData[index + 1].File1Value)
                {
                    var temp = fileData[index];
                    fileData[index] = fileData[index + 1];
                    fileData[index + 1] = temp;
                    swap = true;
                }
            }
        } while (swap);
    }
