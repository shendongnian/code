    public class GPUModule : ILGPUModule
    {
      public GPUModule (GPUModuleTarget target) : base(target)
      {
      }
      [Kernel]
      Public MyKernel(deviceptr<int> Data)
      {
        var start = blockIdx.x * blockDim.x + threadIdx.x;
        int ind = threadIdx.x;
        for (int i=0;i<100;i++)
        {
          //Kernel Code here
        }
      }
      public void Dilimle_VerilerB(deviceptr<int> Data
      {
        ...
        var lp = new LaunchParam(GridDim, BlockDim);
        GPULaunch(TestKernel, lp, Data, HOIndex);
        ...
      }
    }
    
