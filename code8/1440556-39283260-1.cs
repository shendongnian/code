    namespace Emgu.CV.SerializationSurrogates
    {
        using Emgu.CV;
        public class Matix<TDepth> where TDepth : new()
        {
            [XmlAttribute]
            public int Rows { get; set; }
            [XmlAttribute]
            public int Cols { get; set; }
            [XmlAttribute]
            public int NumberOfChannels { get; set; }
            [XmlAttribute]
            public int CompressionRatio { get; set; }
            public byte[] Bytes { get; set; }
            public static implicit operator Emgu.CV.SerializationSurrogates.Matix<TDepth>(Emgu.CV.Matrix<TDepth> matrix)
            {
                if (matrix == null)
                    return null;
                return new Matix<TDepth>
                {
                    Rows = matrix.Rows,
                    Cols = matrix.Cols,
                    NumberOfChannels = matrix.NumberOfChannels,
                    CompressionRatio = matrix.SerializationCompressionRatio,
                    Bytes = matrix.Bytes,
                };
            }
            public static implicit operator Emgu.CV.Matrix<TDepth>(Matix<TDepth> surrogate)
            {
                if (surrogate == null)
                    return null;
                var matrix = new Emgu.CV.Matrix<TDepth>(surrogate.Rows, surrogate.Cols, surrogate.NumberOfChannels);
                matrix.SerializationCompressionRatio = surrogate.CompressionRatio;
                matrix.Bytes = surrogate.Bytes;
                return matrix;
            }
        }
        public class IntrinsicCameraParameters
        {
            [XmlElement("IntrinsicMatrix", Type = typeof(Emgu.CV.SerializationSurrogates.Matix<double>))]
            public Emgu.CV.Matrix<double> IntrinsicMatrix { get; set; }
            [XmlElement("DistortionCoeffs", Type = typeof(Emgu.CV.SerializationSurrogates.Matix<double>))]
            public Emgu.CV.Matrix<double> DistortionCoeffs { get; set; }
            public static implicit operator Emgu.CV.SerializationSurrogates.IntrinsicCameraParameters(Emgu.CV.IntrinsicCameraParameters icp)
            {
                if (icp == null)
                    return null;
                return new IntrinsicCameraParameters
                {
                    DistortionCoeffs = icp.DistortionCoeffs,
                    IntrinsicMatrix = icp.IntrinsicMatrix,
                };
            }
            public static implicit operator Emgu.CV.IntrinsicCameraParameters(Emgu.CV.SerializationSurrogates.IntrinsicCameraParameters surrogate)
            {
                if (surrogate == null)
                    return null;
                return new Emgu.CV.IntrinsicCameraParameters
                {
                    DistortionCoeffs = surrogate.DistortionCoeffs,
                    IntrinsicMatrix = surrogate.IntrinsicMatrix,
                };
            }
        }
    }
