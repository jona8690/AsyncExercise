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
            Console.WriteLine("Here are the numbers from the server: ");

            int[] numbers = mServer.GetNumbers(20, 1, 5);

            foreach (int x in numbers)
            {
                Console.WriteLine(x);
            }
        }
    }
}
