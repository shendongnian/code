    public List<OutputClass> GetOutputs(InputClass input1, OtherInputClass input2)
    {
        var outputs = new List<OutputClass>();
        if (input1 == null || input2 == null)
        {
            return outputs;
        }
        // continue with processing
        // do something with input1
        OutputClass output1 = GetOutput(input1.SomeValue);
        // do something with input2
        OutputClass output2 = GetOutput(new CustomClass(input2.AnotherValue));
        // create outputs based on the input data
        outputs.Add(output1);
        outputs.Add(output2);
        return outputs;
    }
