    var lion = ....;
    var bird = ....;
    var mouse = ....;
    process(lion);
    process(bird);
    process(mouse);
    //if the fixed list is not too long
    //consider using [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Process(Animal animal) { ... }
