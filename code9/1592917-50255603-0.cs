        public override void StdIn(out string input, int count)
        {
            var buffer = new char[count];
            Console.In.ReadBlock(buffer, 0, count);
            input = buffer[0] == '\0'
                  ? null
                  : new string(buffer);
        }
