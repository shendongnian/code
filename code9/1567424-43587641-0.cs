    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    namespace UnsafeTypes
    {
      /// <summary>Represents a hash of a string or byte array</summary>
      [StructLayout( LayoutKind.Sequential )]
      public unsafe struct Hash: IComparable<Hash>
      {
        /// <summary>Returns the length of any <see cref="Hash"/></summary>
        public const int Length = 64;
        /// <summary>Returns a <see cref="HashAlgorithm"/> that the system uses to compute hashes</summary>
        public static HashAlgorithm GetHasher( )
        {
          return new SHA512Managed( );
        }
        /// <summary>Character map for byte array to string</summary>
        readonly static char[ ] hex = new char[ ] {
              '0', '1', '2', '3',
              '4', '5', '6', '7',
              '8', '9', 'a', 'b',
              'c', 'd', 'e', 'f' };
        /// <summary>Synchronization primitive</summary>
        readonly static object sync = new object( );
        /// <summary>Buffer for reading hashes from streams and arrays</summary>
        readonly static byte[ ] buffer = new byte[ Length ];
        /// <summary>ToString workspace</summary>
        static char[ ] hexChars = new char[ Length * 2 ];
        /// <summary>Returns a hash that has no value</summary>
        public readonly static Hash EmptyHash = new Hash( );
        /// <summary>A pointer to the underlying data</summary>
        fixed byte value[ Length ];
        /// <summary>Creates a hash from a string</summary>
        public Hash( string hashable )
        {
          fixed ( byte* bytes = value, sourceBytes = GetHasher( ).ComputeHash( Encoding.Unicode.GetBytes( hashable ) ) )
          {
            NativeMethods.CopyMemory( bytes, sourceBytes, Length );
          }
        }
        /// <summary>Creates a hash from a byte array</summary>
        public Hash( byte[ ] source, int index, int length )
        {
          fixed ( byte* bytes = value, sourceBytes = GetHasher( ).ComputeHash( source, index, length ) )
          {
            NativeMethods.CopyMemory( bytes, sourceBytes, Length );
          }
        }
        /// <summary>Copies the hash to the start of a byte array</summary>
        public void CopyTo( byte[ ] buffer )
        {
          CopyTo( buffer, 0 );
        }
        /// <summary>Copies the hash to a byte array</summary>
        public void CopyTo( byte[ ] buffer, int offset )
        {
          if ( buffer == null ) throw new ArgumentNullException( nameof( buffer ) );
          if ( buffer.Length < ( offset + Length ) ) throw new ArgumentOutOfRangeException( nameof( buffer ) );
          fixed ( byte* bytes = value, dest = buffer )
          {
            NativeMethods.CopyMemory( dest + offset, bytes, Length );
          }
        }
        /// <summary>Returns a byte-array representation of the <see cref="Hash"/></summary>
        /// <remarks>The returned value is a copy</remarks>
        public byte[ ] GetBytes( )
        {
          var results = new byte[ Length ];
          fixed ( byte* bytes = value, target = results )
          {
            NativeMethods.CopyMemory( target, bytes, Length );
          }
          return results;
        }
        /// <summary>Compares this hash to another</summary>
        public int CompareTo( Hash other )
        {
          var comparedByte = 0;
          fixed ( byte* bytes = value )
          {
            for ( int i = 0; i < Length; i++ )
            {
              comparedByte = ( *( bytes + i ) ).CompareTo( other.value[ i ] );
              if ( comparedByte != 0 ) break;
            }
            return comparedByte;
          }
        }
        /// <summary>Returns true if <paramref name="obj"/> is a <see cref="Hash"/> and it's value exactly matches</summary>
        /// <param name="obj">The <see cref="Hash"/> to compare to this one</param>
        /// <returns>true if the values match</returns>
        public override bool Equals( object obj )
        {
          if ( obj == null || !( obj is Hash ) ) return false;
          var other = ( Hash ) obj;
          return CompareTo( other ) == 0;
        }
        /// <summary>Returns a .Net hash code for this <see cref="Hash"/></summary>
        public override int GetHashCode( )
        {
          unchecked
          {
            int hashCode = 17;
            fixed ( byte* bytes = value )
            {
              for ( int i = 0; i < Length; i++ )
              {
                hashCode = hashCode * 31 + *( bytes + i );
              }
              return hashCode;
            }
          }
        }
        /// <summary>Returns a hex string representation of the hash</summary>
        public override string ToString( )
        {
          lock ( sync )
          {
            fixed ( char* hexFixed = hex, hexCharsFixed = hexChars )
            {
              fixed ( byte* bytes = value )
              {
                for ( int i = 0; i < Length; i++ )
                {
                  *( hexCharsFixed + ( i * 2 ) ) = *( hexFixed + ( *( bytes + i ) >> 4 ) );
                  *( hexCharsFixed + ( 1 + ( i * 2 ) ) ) = *( hexFixed + ( *( bytes + i ) & 0xf ) );
                }
                return new string( hexChars );
              }
            }
          }
        }
        /// <summary>Reads a <see cref="Hash"/> from the provided stream</summary>
        public void Read( Stream stream )
        {
          lock ( sync )
          {
            var retryCount = 0;
            var bytesRead = ReadStream( stream, buffer, 0, Length, ref retryCount );
            if ( bytesRead == Length )
            {
              fixed ( byte* bytes = value, sourceBytes = buffer )
              {
                NativeMethods.CopyMemory( bytes, sourceBytes, Length );
              }
            }
          }
        }
        /// <summary>Tries hard to populate a <see cref="Hash"/> from a stream - across multiple reads if necessary - up to a point</summary>
        int ReadStream( Stream stream, byte[ ] buffer, int offset, int length, ref int retryCount )
        {
          const int maxStreamReadRetries = 3;
          var bytesRead = stream.Read( buffer, offset, length );
          var done = bytesRead == 0 || bytesRead == length;  // eos, timeout, or success
          if ( !done )
          {
            if ( retryCount++ >= maxStreamReadRetries ) return 0;
            bytesRead += ReadStream( stream, buffer, bytesRead, length - bytesRead, ref retryCount );
          }
          return bytesRead;
        }
        /// <summary>Writes the hash to a stream</summary>
        public void Write( Stream stream )
        {
          lock ( sync )
          {
            fixed ( byte* bytes = value, targetBytes = buffer )
            {
              NativeMethods.CopyMemory( targetBytes, bytes, Length );
            }
            stream.Write( buffer, 0, Length );
          }
        }
        /// <summary>Returns true if the hash has no value</summary>
        public bool IsEmpty( )
        {
          return Equals( EmptyHash );
        }
        /// <summary>Implements == operator</summary>
        public static bool operator ==( Hash a, Hash b )
        {
          return a.Equals( b );
        }
        /// <summary>Implements != operator</summary>
        public static bool operator !=( Hash a, Hash b )
        {
          return !a.Equals( b );
        }
        /// <summary>Converts a byte array to a <see cref="Hash"/></summary>
        public static Hash FromBytes( byte[ ] hashBytes, int offset = 0 )
        {
          if ( hashBytes == null ) throw new ArgumentNullException( nameof( hashBytes ) );
          if ( ( hashBytes.Length + offset ) < Length ) throw new ArgumentOutOfRangeException( nameof( hashBytes ) );
          var hash = new Hash( );
          fixed ( byte* sourceBytes = hashBytes )
            NativeMethods.CopyMemory( hash.value, sourceBytes + offset, Length );
          return hash;
        }
      }
      class NativeMethods
      {
        [DllImport( "Kernel32", SetLastError = true, EntryPoint = "CopyMemory" )]
        internal unsafe static extern void CopyMemory( void* destination, void* source, uint length );
      }
      static class Extensions
      {
        /// <summary>Applies action to each element of the collection.</summary>
        public static void Do<T>( this IEnumerable<T> enumerable, Action<T> action )
        {
          if ( enumerable == null ) throw new ArgumentNullException( "enumerable" );
          if ( action == null ) throw new ArgumentNullException( "action" );
          foreach ( var item in enumerable ) action( item );
        }
      }
    }
