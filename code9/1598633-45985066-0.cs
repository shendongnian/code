    public class MyCharacterDevice : RDotNet.Devices.ICharacterDevice
    {
        public StringBuilder sb = new StringBuilder();
        public void WriteConsole(string output, int length, RDotNet.Internals.ConsoleOutputType outputType)
        {
            sb.Append(output);
        }
        
        //rest of the implementation here
    }
