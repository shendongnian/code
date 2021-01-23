    SomeObject head = null; // References first object
    SomeObject tail = null; // References last object.
    // Add object
    var item = new SomeObject();
    if (tail == null) { // head is null as well.
        head = item;
        tail = item;
    } else {
        tail.obj = item;
        tail = item;
    }
