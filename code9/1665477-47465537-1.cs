        public static string EncodeRoles(IEnumerable<string> roles)
        {
            byte[] bitMask = new byte[(int)CustomRoles.MaxRole];
            foreach (var role in roles)
            {
                CustomRoles roleIndex = (CustomRoles)Enum.Parse(typeof(CustomRoles), role);
                var byteIndex = ((int)roleIndex) / 8;
                var bitIndex = ((int)roleIndex) % 8;
                bitMask[byteIndex] |= (byte)(1 << bitIndex);
            }
            return Convert.ToBase64String(bitMask);
        }
        public static IEnumerable<string> DecodeRoles(string encoded)
        {
            byte[] bitMask = Convert.FromBase64String(encoded);
            var values = Enum.GetValues(typeof(CustomRoles)).Cast<CustomRoles>().Where(r => r != CustomRoles.MaxRole);
            var roles = new List<string>();
            foreach (var roleIndex in values)
            {
                var byteIndex = ((int)roleIndex) / 8;
                var bitIndex = ((int)roleIndex) % 8;
                if ((byteIndex < bitMask.Length) && (0 != (bitMask[byteIndex] & (1 << bitIndex))))
                {
                    roles.Add(Enum.GetName(typeof(CustomRoles), roleIndex));
                }
            }
            return roles;
        }
