        public class BooleanSet
    {
        private List<ulong> values = new List<ulong>();
        private int count = 0;
        /* 0x8000000000000000UL is the same as the binary number 1000000000000000000000000000000000000000000000000000000000000000 */
        private const ulong MsbFilterMask = 0x8000000000000000UL;
        /* 0xfffffffffffffffeUL is the same as the binary number 1111111111111111111111111111111111111111111111111111111111111110 */
        private const ulong LsbEraserMask = 0xfffffffffffffffeUL;
        public BooleanSet()
        {
            /* the set mut be initialized with a 0 value */
            values.Add(0);
        }
        /// <summary>
        /// Append a new boolean value to the list
        /// </summary>
        /// <param name="newValue">New value to append</param>
        public void Append(bool newValue)
        {
            /* Each element in list can store up to 64 boolean values.
             * If is number is going to be overcome, the set must grow up.
             */
            if (count % 64 == 63)
            {
                values.Add(0);
            }
            count++;
            /* now  we just have to shift the whole thing left, but we have
             * to preserve the MSB for lower elements:
             * 
             * We have to initialize the last MSB (Most Significant Bit) with the new value.
             */
            ulong lastMsb = newValue ? 0x1UL : 0x0UL;
            for (int position = 0; position < values.Count; position++)
            {
                /* & is the bitwhise operator AND
                 * It is used as a mask to zero fill anything, except the MSB;
                 * After get the MSB isolated, we just have to shift it to right edge (shift right 63 times)
                 */
                ulong currentMsb = (values[position] & MsbFilterMask) >> 63;
                /* Now we have discart MSB and append a new LSB (Less Significant Bit) to the current value.
                 * The | operator is the bitwise OR
                 */
                values[position] = ((values[position] << 1) & LsbEraserMask) | lastMsb;
                lastMsb = currentMsb;
            }
            /* We don't have to take care of the last value, because we have did this already (3 1sf lines of this methid) */
        }
        public override string ToString()
        {
            /* Now we have to write the set as a string */
            StringBuilder sb = new StringBuilder();
            /* We have to keep track of the total item count */
            int totalCount = count;
            string separator = "";
            foreach (ulong value in this.values)
            {
                /* for each value in the internal list, we have to create a new bit mask */
                ulong bitMask = 1;
                /* We have to get all bits of all values, except the last one, because it may not be full.
                 * the totalCount will let us to know where we reach the end of the list.
                 */
                for (int pos = 0; pos < 64 && totalCount > 0; pos++, totalCount--)
                {
                    /* We have to write the string in reverse order, because the first item is in the end of our list */
                    sb.Insert(0, separator);
                    sb.Insert(0, (value & bitMask) > 0);
                    separator = ", ";
                    bitMask = bitMask << 1;
                }
            }
            return sb.ToString();
        }
    }
