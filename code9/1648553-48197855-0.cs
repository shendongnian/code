    namespace ConsoleApp2 {
        using System;
        class Program {
            static void Main(string[] args) {
                while (true) {
                    try {
                        throw new Exception();
                    } catch (Exception) { }
                }
            }
        }
    }
