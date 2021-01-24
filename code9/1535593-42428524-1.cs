     CoresGpu gpu = new CoresGpu(kernelString,options,"gpu");
     for(i 0 to 100)
     {
       float [] results = new float[n];
       // allocate new, if only not enough, deallocate old, if only not used
       gpu.compute(new object[]{getVideoFeedBuffer(),brush21x21array,results},
                 new string[]{"input","input","output"},
                 kernelName,numberOfThreads);
       toCloudDb(results.toList());
     }
      
     gpu.release(); // everything is released here
