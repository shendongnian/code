    public float shakeMultiplier = 1.0f;
    public float shakeTimeScale = 1.0f;
    // These values won't be changed
    public float baseShakeDuration = 1.0f;
    public float baseShakeStrength = 0.1f;
    public int baseShakeVibrato = 10;
    Vector3 shakePosition;
    Tweener shakeTween;
    void Start()
    {
        shakeTween = DOTween.Shake(() => shakePosition, x => shakePosition = x, baseShakeDuration, baseShakeStrength, baseShakeVibrato, fadeOut: true)
               .SetLoops(-1, LoopType.Restart);
    }
    void Update()
    {
        transform.localPosition = shakePosition * shakeMultiplier;
        shakeTween.timeScale = shakeTimeScale;
    }
