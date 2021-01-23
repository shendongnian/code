    int index = -1;
    for (int i = 0; i < LibrariesAndBooks.Count; i++)
        // Assuming Libraries has a Name property
        if (((Libraries)LibrariesAndBooks[i]).Name == selectedItem)
        {
            index = i;
            break;
        }
