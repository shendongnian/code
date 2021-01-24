    public override void AwakeFromNib()
    {
    	base.AwakeFromNib();
    
    	var binding = this.CreateBindingSet<MyCell, MyCellViewModel>();
        binding.Bind(this.TextView.Text).To(vm => vm.GetType().Name).WithConversion(new StringFormatConverter(), "Unknown cell type: {0}");
        binding.Apply();
    }
