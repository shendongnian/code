    public class ConfigHookReader : StreamReader
    {
        public override int Read(char[] buffer, int index, int count)
        {
            var read = base.Read(buffer, index, count);
    
            // EDIT (original) for (int i = 0; i < buffer.Length; i++)
            for (int i = 0; i < read; i++)
            {
                if (buffer[i] == 'A')
                    buffer[i] = 'B';
            }
    
            return read;
        }
    }
