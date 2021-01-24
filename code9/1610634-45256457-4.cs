    Imports Microsoft.VisualBasic
    Imports System.Runtime.CopilerServices
    Imports System.Runtime.InteropServices
    
    Namespace bgmcproject
      <Guid("3C69B26B-8D17-11D3-BA9C-00E09803AA6A"), ClassInterface(0), ComSourceInterfaces("bgmcproject.__bgmc" & vbNullChar & vbNullChar), TypeLibType(32), ComImport>
      Public Class bgmcClass
    	  Inherits _bgmc
    	  Implements bgmc, __bgmc_Event
    
    	<DispId(1745027134)>
    	Public Overridable WriteOnly Property szMachineImg() As String
    		<DispId(1745027134), MethodImpl(MethodImplOptions.InternalCall, MethodCodeType := MethodCodeType.Runtime), param:= MarshalAs(UnmanagedType.BStr), [In]>
    		Set(ByVal value As String)
    		End Set
    	End Property
      End Class
    End Namespace
