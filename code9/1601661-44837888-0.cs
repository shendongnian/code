    private void button4_Click(object sender, EventArgs e)
    {
    
      ComputeContextPropertyList Properties = new ComputeContextPropertyList(ComputePlatform.Platforms[1]);
      ComputeContext Context = new ComputeContext(ComputeDeviceTypes.All, Properties, null, IntPtr.Zero);
    
      //define a function template that sum two vectors 
      string vecSum = @" 
        __kernel void
        floatVectorSum(__global float * v1,
        __global float * v2)
        {
         int i = get_global_id(0);
         v1[i] = v1[i] + v2[i];
        }
    
        ";
      //add gpu devices into list for executing the vecSum function defined at last step
      List<ComputeDevice> Devs = new List<ComputeDevice>();
      Devs.Add(ComputePlatform.Platforms[1].Devices[0]);
      Devs.Add(ComputePlatform.Platforms[1].Devices[1]);
      Devs.Add(ComputePlatform.Platforms[1].Devices[2]);
      //define a compute programe with function define and gpu devices specified.
      ComputeProgram prog = null;
      try
      {
    
        prog = new ComputeProgram(Context, vecSum); prog.Build(Devs, "", null, IntPtr.Zero);
      }
    
    
      catch
    
      { }
    
      
      ComputeKernel kernelVecSum = prog.CreateKernel("floatVectorSum");
    
      //init the vectors need by the vecSum.
      float[] v1 = new float[100], v2 = new float[100];
      for (int i = 0; i < v1.Length; i++)
      {
        v1[i] = i;
        v2[i] = 2 * i;
      } 
      //create parametes needed as pass in parameter for vecSum.
      ComputeBuffer<float> bufV1 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v1);
      ComputeBuffer<float> bufV2 = new ComputeBuffer<float>(Context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, v2);
      //pass the parameters in.
      kernelVecSum.SetMemoryArgument(0, bufV1);
      kernelVecSum.SetMemoryArgument(1, bufV2);
      //queue your compute request.
      ComputeCommandQueue Queue = new ComputeCommandQueue(Context, Cloo.ComputePlatform.Platforms[1].Devices[0], Cloo.ComputeCommandQueueFlags.None);
      //execute your compute request
      Queue.Execute(kernelVecSum, null, new long[] { v1.Length }, null, null);
      //clean the resource and read the result from the queue
      float[] arrC = new float[100];
      GCHandle arrCHandle = GCHandle.Alloc(arrC, GCHandleType.Pinned);
      Queue.Read<float>(bufV1, true, 0, 100, arrCHandle.AddrOfPinnedObject(), null);
     }
