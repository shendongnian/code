	public class B
	{
		public BE GetEnumerator()
		{
			return new BE();
		}
		
		public struct BE
		{
			public object Current {
				get {
					throw new NotImplementedException();
				}
			}
			
			public bool MoveNext()
			{
				throw new NotImplementedException();
			}
			
			public void Reset()
			{
				throw new NotImplementedException();
			}
		}
	}
----
	  .locals init (class [mscorlib]System.Collections.IEnumerator V_0,
	           class [mscorlib]System.IDisposable V_1,
	           valuetype Testing.Program/B/BE V_2,
	           object[] V_3,
	           int32 V_4)
	  IL_002f:  newobj     instance void Testing.Program/B::.ctor()
	  IL_0034:  call       instance valuetype Testing.Program/B/BE Testing.Program/B::GetEnumerator()
	  IL_0039:  stloc.2
	  IL_003a:  br.s       IL_0044
	  IL_003c:  ldloca.s   V_2
	  IL_003e:  call       instance object Testing.Program/B/BE::get_Current()
	  IL_0043:  pop
	  IL_0044:  ldloca.s   V_2
	  IL_0046:  call       instance bool Testing.Program/B/BE::MoveNext()
	  IL_004b:  brtrue.s   IL_003c
