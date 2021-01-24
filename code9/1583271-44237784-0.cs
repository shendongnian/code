            var inputsCount = inputs.Count;
            var buffer =new double[inputsCount % 2 == 0 ? inputsCount + 2 : inputsCount + 1];
            int j = 0;
            
            foreach (var point in inputs)
            {
                buffer[j] = point.Y;
                j++;
            }
            try
            {
                MathNet.Numerics.IntegralTransforms.Fourier.ForwardReal(buffer, inputsCount, FourierOptions.Matlab);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
