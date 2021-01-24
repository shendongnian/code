    public static Object ProcessJSON(Object obj) { 
        
        List<Object> objetsToProcess = new ArrayList<>();
        
        objetsToProcess.add(obj);
        
        while (objetsToProcess.size() > 0) {
            
            Object temp = objetsToProcess.get(0);
            objetsToProcess.remove(0);
            
            // Process "temp"
            // If it's another object that needs processed then use "objectsToProcess.add(temp);"
            
        }
        
        // post processing code
        
        return obj;
        
    }
