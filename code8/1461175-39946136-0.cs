    using MathNet.Numerics.Data.Text;
    using MathNet.Numerics.LinearAlgebra;
	
    public void DivideMatrixByScalar(string inputFilename, string outputFileName, double scalar)
	{
		Matrix<double> matrix;
		using (var sr = new StreamReader(inputFilename))
		{
			matrix = DelimitedReader.Read<double>(sr, false, "\\s", false, CultureInfo.InvariantCulture.NumberFormat);
		}
		// Divide all values with the scalar.
		matrix = matrix.Divide(scalar);
		using (var sw = new StreamWriter(outputFileName))
		{
			DelimitedWriter.Write(sw, matrix, " ", null, "0.0000", CultureInfo.InvariantCulture.NumberFormat);
		}
	}
