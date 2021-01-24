    public static unsafe void Fill<T>(this Span<T> span, [NotNull] Func<T> provider)
    {
        int
            cores = Environment.ProcessorCount,
            batch = span.Length / cores,
            mod = span.Length % cores,
            size = Unsafe.SizeOf<T>();
        ref T r0 = ref span.DangerousGetPinnableReference();
        fixed (byte* p0 = &Unsafe.As<T, byte>(ref r0))
        {
            byte* pc = p0;
            Parallel.For(0, cores, i =>
            {
                byte* p = pc + i * batch * size;
                for (int j = 0; j < batch; j++, p += size)
                    Unsafe.Write(p, provider());
            }).AssertCompleted();
            // Remaining values
            if (mod < 1) return;
            for (int i = span.Length - mod; i < span.Length; i++)
                Unsafe.Write(pc + i * size, provider());
        }
    }
