    private static DigestRandomGenerator CreatePrng(string digestName, bool autoSeed)
    {
        IDigest digest = DigestUtilities.GetDigest(digestName);
        if (digest == null)
            return null;
        DigestRandomGenerator prng = new DigestRandomGenerator(digest);
        if (autoSeed)
        {
            prng.AddSeedMaterial(NextCounterValue());
            prng.AddSeedMaterial(GetNextBytes(Master, digest.GetDigestSize()));
        }
        return prng;
    }
