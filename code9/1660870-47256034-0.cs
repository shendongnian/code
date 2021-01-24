    public static class Extensions
    {
        //
        // Summary:
        //     /// Performs an Android runtime-checked type conversion. ///
        //
        // Parameters:
        //   instance:
        //     /// An Android.Runtime.IJavaObject instance to convert /// to a TResult instance.
        //     ///
        //
        // Type parameters:
        //   TResult:
        //     /// The type to convert instance to. /// TResult must implement the /// Android.Runtime.IJavaObject
        //     interface. ///
        //
        // Returns:
        //     /// A TResult representation for /// instance. ///
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     ///
        //     /// The JNI class for TResult cannot be found. ///
        //     ///
        //     -or-
        //     ///
        //     /// The proxy class for TResult is /// abstract, and the non-abstract Proxy can't
        //     be found. ///
        //     ///
        //
        //   T:System.InvalidCastException:
        //     /// The Anrdroid object instance instance.Handle /// cannot be converted to the
        //     Android type corresponding to /// TResult. ///
        //
        //   T:System.NotSupportedException:
        //     /// An unknown error occurred. ///
        //
        // Remarks:
        //     /// /// This is a hack, but a currently necessary one. /// ///
        //     /// Most of the Android types are staticly generated /// wrappers over a description
        //     of the underlying Android types. This /// intermediate description does not expose
        //     implementation details, /// which sometimes must be relied upon. ///
        //     ///
        //     /// For example, consider the /// Javax.Microedition.Khronos.Egl.EGLContext.EGL
        //     /// property, which returns an instance of the /// Javax.Microedition.Khronos.Egl.IEGL
        //     /// interface. This interface is useless, containing no members to /// invoke
        //     or use. The developer is instead expected to convert this /// instance to an
        //     interface which contains actual operations, such as /// the Javax.Microedition.Khronos.Egl.IEGL10
        //     interface. /// Unfortunately, the MonoDroid-generated wrappers do not know this,
        //     /// nor can they (the EGL10 implementation may be removed in a /// future Android
        //     version). The result is that if developers attempt /// to cast within managed
        //     code, the result will be a /// System.InvalidCastException: ///
        //     /// EGL10 egl10 = (EGL10) EGLContext.EGL; // throws ///
        //     /// The JavaCast() method allows performing such type conversions /// while bypassing
        //     the managed type system and instead relying upon /// the Android runtime system
        //     to perform the type checking. This /// allows: ///
        //     /// EGL10 egl10 = EGLContext.EGL.JavaCast<EGL10>(); // good ///
        public static TResult JavaCast<TResult>(this IJavaObject instance) where TResult : class, IJavaObject;
    }
