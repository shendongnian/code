       public class StringMask : IStringMask
        {
            /// <summary>
            /// The Mask character
            /// </summary>
            private readonly char MaskCharacter;
    
            /// <summary>
            /// The instance
            /// </summary>
            private readonly string Instance;
    
            /// <summary>
            /// The Mask
            /// </summary>
            private BitArray Mask;
    
            /// <summary>
            /// Initializes a new instance of the <see cref="StringMask"/> class.
            /// </summary>
            /// <param name="instance">The string you would like to mask.</param>
            /// <param name="maskCharacter">The Mask character.</param>
            public StringMask(string instance, char maskCharacter)
            {
                MaskCharacter = maskCharacter;
                Instance = instance;
                Mask = new BitArray(instance.Length, false);
            }
    
           
    
            /// <summary>
            /// Shows the first [number] of characters and masks the rest.
            /// </summary>
            /// <param name="number">The number of the characters to show.</param>
            /// <returns>IStringMask.</returns>
            public IStringMask ShowFirst(int number)
            {
                Validate(number);
    
                for (int i = 0; i < number; i++)
                {
                    Mask[i] = true;
                }
                return this;
            }
    
            /// <summary>
            /// Shows the last [number] of characters and masks the rest.
            /// </summary>
            /// <param name="number">The number of the characters to show.</param>
            /// <returns>IStringMask.</returns>
            public IStringMask ShowLast(int number)
            {
                Validate(number);
    
                for (int i = 0; i < number; i++)
                {
                    Mask[Instance.Length - i - 1] = true;
                }
                return this;
    
            }
    
            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
            public override string ToString()
            {
                var sb = new StringBuilder();
                for (int i = 0; i < Instance.Length; i++)
                {
                    if (Mask[i])
                        sb.Append(Instance[i]);
                    else
                        sb.Append(MaskCharacter);
                }
    
                return sb.ToString();
            }
    
            private void Validate(int number)
            {
                Guard.IsBetweenExclusive(number, 0, Instance.Length, nameof(number));
            }
        }
