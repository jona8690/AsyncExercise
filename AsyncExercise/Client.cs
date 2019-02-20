using System;
namespace AsyncExercise
{
    public class Client
    {
        private readonly Server mServer;

        public Client(Server server)
        {
            mServer = server;
        }

        public void run()
        {
            while (true)
            {
                int number = GetNumber("Enter a number (0 for stop): ");

                int[] numbers = mServer.GetNumbers(number, 1, 6);

                Console.WriteLine("Here are the numbers from the server: ");

                foreach (int x in numbers)
                {
                    Console.WriteLine(x);
                }
            }
        }

        private int GetNumber(String text)
        {
            Console.WriteLine(text);
            return int.Parse(Console.ReadLine());
        }


    }
}
