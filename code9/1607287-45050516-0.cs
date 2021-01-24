	/// <summary>
	/// Implements WPF's Matrix.Multiply on Silverlight.
	/// </summary>
	/// <param name="matrix1">First matrix.</param>
	/// <param name="matrix2">Second matrix.</param>
	/// <returns>Multiplication result.</returns>
	private static Matrix MatrixMultiply(Matrix matrix1, Matrix matrix2)
	{
		// WPF equivalent of following code:
		// return Matrix.Multiply(matrix1, matrix2);
		return new Matrix(
			(matrix1.M11 * matrix2.M11) + (matrix1.M12 * matrix2.M21),
			(matrix1.M11 * matrix2.M12) + (matrix1.M12 * matrix2.M22),
			(matrix1.M21 * matrix2.M11) + (matrix1.M22 * matrix2.M21),
			(matrix1.M21 * matrix2.M12) + (matrix1.M22 * matrix2.M22),
			((matrix1.OffsetX * matrix2.M11) + (matrix1.OffsetY * matrix2.M21)) + matrix2.OffsetX,
			((matrix1.OffsetX * matrix2.M12) + (matrix1.OffsetY * matrix2.M22)) + matrix2.OffsetY);
	}
