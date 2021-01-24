    QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
    QrCode qrCode = qrEncoder.Encode(url);
    for (int j = 0; j < qrCode.Matrix.Height; j++)
    {
        for (int i = 0; i < qrCode.Matrix.Width; i++)
        {
            char charToPoint = qrCode.Matrix[i, j] ? '█' : ' ';
            Console.Write(charToPoint);
        }
        Console.WriteLine();
    }
}
