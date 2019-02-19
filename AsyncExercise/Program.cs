using System;

namespace AsyncExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            new Client(new Server()).run();
        }
    }
}
