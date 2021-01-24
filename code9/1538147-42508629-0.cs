    namespace Foo {
        class Bar {}
        namespace Bat {
            namespace Foo {
                class Bar {}
            }
            static class Test {
                public static void AccessNS() {
                    //The global:: alias is necessary here to avoid a creating a Foo.Bat.Foo.Bar()
                    var fooBar = new global::Foo.Bar();
                }
            }
         }
    }
