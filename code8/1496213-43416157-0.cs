    using System;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace Wteen.Infrastructure.Services
    {
        /// <summary>
        /// An Time Based Implementation of RFC 6248, a variation from the OTP (One Time Password) with, a default code life time of 30 seconds.
        /// </summary>
        public sealed class TotpAuthenticationService
        {
            private readonly Encoding _encoding;
            private readonly int _length;
            private readonly TimeSpan _timestep;
            private readonly DateTime _unixEpoch;
    
            /// <summary>
            /// Create a new Instance of <see cref="TotpAuthenticationService"/>
            /// </summary>
            /// <param name="length">The length of the OTP</param>
            /// <param name="duration">The peried of time in which the genartion of a OTP with the result with the same value</param>
            public TotpAuthenticationService(int length, int duration = 30)
            {
                _length = length;
                _encoding = new UTF8Encoding(false, true);
                _timestep = TimeSpan.FromSeconds(duration);
                _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            }
    
            /// <summary>
            /// The current time step number
            /// </summary>
            private ulong CurrentTimeStepNumber => (ulong)(TimeElapsed.Ticks / _timestep.Ticks);
    
            /// <summary>
            /// The number of seconds elapsed since midnight UTC of January 1, 1970.
            /// </summary>
            private TimeSpan TimeElapsed => DateTime.UtcNow - _unixEpoch;
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="securityToken"></param>
            /// <param name="modifier"></param>
            /// <returns></returns>
            public int GenerateCode(byte[] securityToken, string modifier = null)
            {
                if (securityToken == null)
                    throw new ArgumentNullException(nameof(securityToken));
    
                using (var hmacshA1 = new HMACSHA1(securityToken))
                {
                    return ComputeTotp(hmacshA1, CurrentTimeStepNumber, modifier);
                }
            }
    
            /// <summary>
            /// Validating for codes generated during the current and past code generation <see cref="timeSteps"/>
            /// </summary>
            /// <param name="securityToken">User's secerct</param>
            /// <param name="code">The code to validate</param>
            /// <param name="timeSteps">The number of time steps the <see cref="code"/> could be validated for.</param>
            /// <param name="channel">Possible channels could be user's email or mobile number where the code will be sent to</param>
            /// <returns></returns>
            public bool ValidateCode(byte[] securityToken, int code, int timeSteps, string channel = null)
            {
                if (securityToken == null)
                    throw new ArgumentNullException(nameof(securityToken));
    
                using (var hmacshA1 = new HMACSHA1(securityToken))
                {
                    for (var index = -timeSteps; index <= timeSteps; ++index)
                        if (ComputeTotp(hmacshA1, CurrentTimeStepNumber + (ulong)index, channel) == code)
                            return true;
                }
    
                return false;
            }
    
            private byte[] ApplyModifier(byte[] input, string modifier)
            {
                if (string.IsNullOrEmpty(modifier))
                    return input;
    
                var bytes = _encoding.GetBytes(modifier);
                var numArray = new byte[checked(input.Length + bytes.Length)];
                Buffer.BlockCopy(input, 0, numArray, 0, input.Length);
                Buffer.BlockCopy(bytes, 0, numArray, input.Length, bytes.Length);
                return numArray;
            }
    
            private int ComputeTotp(HashAlgorithm algorithm, ulong timestepNumber, string modifier)
            {
                var bytes = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((long)timestepNumber));
                var hash = algorithm.ComputeHash(ApplyModifier(bytes, modifier));
                var index = hash[hash.Length - 1] & 15;
                return (((hash[index] & sbyte.MaxValue) << 24) | ((hash[index + 1] & byte.MaxValue) << 16) | ((hash[index + 2] & byte.MaxValue) << 8) | (hash[index + 3] & byte.MaxValue)) % (int)Math.Pow(10, _length);
            }
        }
    }
