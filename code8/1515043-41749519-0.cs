            Action consumer = () =>
            {
                int b;
                dataStream.Seek(0, SeekOrigin.Begin);
                do
                {
                    b = dataStream.ReadByte();
                    if (b >= 0)
                        total += b;
                }
                while (b < 255);
            };
