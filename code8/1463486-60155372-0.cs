static int GetBitSize(BigInteger num)
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
static int GetBitSize(BigInteger num)
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
Also a special byte-optimized version which searches in multiples of 8s could be derived from it.
