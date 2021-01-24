    public class ConfigHookReader : StreamReader
    {
        public override int Read(char[] buffer, int index, int count)
        {
            var read = base.Read(buffer, index, count);
    
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == 'A')
                    buffer[i] = 'B';
            }
    
            return read;
        }
    }
