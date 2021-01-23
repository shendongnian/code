static int GetBitSizeReflection(BigInteger num)
{
  //uint[] bits = (uint[])typeof(BigInteger).GetField("_bits", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(num);
  uint[] bits = (uint[])typeof(BigInteger).GetProperty("_Bits", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(num);
  if (bits == null) {
    //int sign = (int)typeof(BigInteger).GetField("_sign", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(num);
    int sign = (int)typeof(BigInteger).GetProperty("_Sign", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(num);
    bits = new uint[] { (uint)(sign < 0 ? sign & int.MaxValue : sign) };
  }
  int uintLength = (int)typeof(BigInteger).GetMethod("Length", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).Invoke(num, new object[] { bits });
  int topbits = (int)typeof(BigInteger).GetMethod("BitLengthOfUInt", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic).Invoke(num, new object[] { bits[uintLength - 1] });
  return (uintLength - 1) * sizeof(uint) * 8 + topbits;
For a `GetByteSize` routine - just use `GetBitSize / 8`.
If you do not want to go into such a hacky solution, then here is a repeated binary search method which should be generally far more efficient though in theory it could require additional comparisons for cases like 3 bits which 1, 2, 3 is faster than 1, 2, 4, 3 though a slight optimization could probably fix that case.  Also it only works for positive BigIntegers in this form:
static int GetBitSizeRecurseBinSearch(BigInteger num)
{ //instead of 0, 1, 2, 3, 4... use 0, 1, 3, 7, 15, etc
  int s = 0, t = 1, oldt = 1;
  if (t <= 0) return 0;
  while (true) {
    if ((BigInteger.One << (s + t)) <= num) { oldt = t; t <<= 1; }
    else if (t == 1) break;
    else { s += oldt; t = 1; }
  }
  return s + 1;
}
Unfortunately this is not very efficient but it certainly beats the naïve way of doing it.
static int GetBitSizeSlow(BigInteger num)
{
  int s = 0;
  while ((BigInteger.One << s) <= num) s++;
  return s;
}
On the other hand, if you want to stay within the framework and still be fast there is also a version that requires only some extra byte copying and is the next fastest after reflection:
static int GetBitSize(BigInteger num)
{
  byte[] bytes = num.ToByteArray();
  int size = bytes.Length;
  if (size == 0) return 0;
  int v = bytes[size - 1]; // 8-bit value to find the log2 of 
  if (v == 0) return (size - 1) * 8;
  int r; // result of log2(v) will go here
  int shift;
  r = (v > 0xF) ? 4 : 0; v >>= r;
  shift = (v > 0x3) ? 2 : 0; v >>= shift; r |= shift;
  r |= (v >> 1);
  return (size - 1) * 8 + r + 1;
}
Finally if really preferring binary search, first you will have to binary search a high value before binary searching normally:
static int GetBitSizeHiSearch(BigInteger num) //power of 2 search high, then binary search
{
  if (num.IsZero) return 0;
  int lo = 0, hi = 1;
  while ((BigInteger.One << hi) <= num) { lo = hi; hi <<= 1; }
  return GetBitSizeBinSearch(num, lo, hi);
}
static int GetBitSizeBinSearch(BigInteger num, int lo, int hi)
{
  int mid = (hi + lo) >> 1;
  while (lo <= hi) {
    if ((BigInteger.One << mid) <= num) lo = mid + 1;
    else hi = mid - 1;
    mid = (hi + lo) >> 1;
  }
  return mid + 1;
}
But the fastest is reflection, followed by getting the bytes, followed by binary search and then recursive binary search and finally the naïve method is the slowest which can be confirmed by profiling as the numbers get increasingly large (at 2^(2^20) it will certainly be obvious).
Also a special byte-optimized version which searches in multiples of 8s could be derived from any of these.
