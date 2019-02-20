using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExercise
{
    public class Server
    {



		/* Return [amount] random numbers between [min] and [max] inclusive */
		public Task<int[]> GetNumbersAsync(int amount, int min, int max)
		{
			return Task.Run(() => GetNumbers(amount, min, max));
		}

		private int[] GetNumbers(int amount, int min, int max)
        {
			Thread.Sleep(2500);
            int[] res = new int[amount];
            Random r = new Random();
            int count = 0;
            while (count < amount)
            {
                int x = r.Next(max - min + 1) + min;
                res[count++] = x;
            }
            return res;
        }
    }
}
