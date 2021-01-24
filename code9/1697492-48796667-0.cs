    var alg = new PHash();
    var hashResult = new Mat();
    //Compute the hash
    alg.Compute(/*some image as Mat*/, hashResult);
    // Get the data from the unmanage memeory
    var data = new byte[hashResult.Width * hashResult.Height];
    Marshal.Copy(hashResult.DataPointer, data, 0, hashResult.Width * hashResult.Height);
    // Concatenate the Hex values representation
    var hashHex = BitConverter.ToString(data).Replace("-", string.Empty);
            
    // hashHex has the hex values concatenation as string;
