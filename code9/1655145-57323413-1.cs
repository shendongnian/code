    public void Evaluate(string word, function model, DeviceDescriptor device)
    {
    // Create Input Dictionary Pair:
    Dictionary<Variable, Value> ModelInput = new Dictionary<Variable, Value>
    {
        { model.Arguments.Single(), Value.CreateBatch<float>(XDim, new int[] { 7 }, DeviceDescriptor.GPUDevice(0), true) }
    };
    // Vector the Model's Output Variable.
    Variable OutputVariable = model.Output;
    // Create Output Dictionary Pair:
    Dictionary<Variable, Value> ModelOutput = new Dictionary<Variable, Value>
    {
        { OutputVariable, null }
    };
    // Evaluate the Model using the Device:
    model.Evaluate(ModelInput, ModelOutput, device);
    // Vector evaluate result as dense output
    IList<IList<float>> OutputValue = ModelOutput[OutputVariable].GetDenseData<float>(OutputVariable);
    IList<float> t = OutputValue[0];
    int index = t.IndexOf(t.Max());
    // Do what you need with your index...
    }
