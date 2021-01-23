        long firstZeroRow = -1;
        long lastZeroRow = -1;
        long rowNum = 0;
        StreamReader srHexFile = File.OpenText(m_pathHexFile);
        while ((readData = srHexFile.ReadLine()) != null){
           rowNum++;
           if (readData.equals(":0000000000" /*or ":0000000000\n"*/)){
               if (firstZeroRow == -1){
                   firstZeroRow = rowNum;
               }
               lastZeroRow = rowNum;
           }
        }
        if (firstZeroRow == -1){
            System.out.println("firstZeroRow: " + firstZeroRow);
            System.out.println("lastZeroRow: " + lastZeroRow);
        }
           
