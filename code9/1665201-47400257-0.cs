    interface IConsumable {
        void draw(Renderer renderer);
    }
    class Apple : IConsumable {
        void draw(Renderer renderer) {
            renderer.DrawApple(this);
        }
    }
    class SegmentRemover : IConsumable {
        void draw(Renderer renderer) {
            renderer.DrawSegmentRemover(this);
        }
    }
