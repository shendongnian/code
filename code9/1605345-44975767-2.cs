    public override void AwakeFromNib()
    {
    	base.AwakeFromNib();
    
    	var binding = this.CreateBindingSet<MyCell, MyCellViewModel>();
        binding.Bind(TextView).To(vm => vm.GetType().Name).WithConversion(new StringFormatConverter(), "Unknown cell type: {0}");
        binding.Apply();
    }
