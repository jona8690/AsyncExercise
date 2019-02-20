using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExercise {
	public class Client {
		private readonly Server mServer;
		private bool Running = true;

		public Client(Server server) {
			mServer = server;
		}

		public void Konami() {
			var KeyHist = new SlidingBuffer<ConsoleKeyInfo>(10);

			while (Running) {
				var key = Console.ReadKey();
				KeyHist.Add(key);

				var konami = new Queue<ConsoleKey>();
				konami.Enqueue(ConsoleKey.UpArrow);
				konami.Enqueue(ConsoleKey.UpArrow);
				konami.Enqueue(ConsoleKey.DownArrow);
				konami.Enqueue(ConsoleKey.DownArrow);
				konami.Enqueue(ConsoleKey.LeftArrow);
				konami.Enqueue(ConsoleKey.RightArrow);
				konami.Enqueue(ConsoleKey.LeftArrow);
				konami.Enqueue(ConsoleKey.RightArrow);
				konami.Enqueue(ConsoleKey.B);
				konami.Enqueue(ConsoleKey.A);

				foreach (var k in KeyHist.GetQueue()) {
					var nextKey = konami.Dequeue();
					if (!(nextKey == k.Key)) return;
				}
			}
		}

		public void run() {

			//new Thread(Konami).Start();

			while (Running) {
				var number = AskForNumbers();
				if (number == 0) return;

				GetNumbers(number, 1, 6, WriteNumbers);
			}
		}

		public int AskForNumbers() {
			int number;
			try {
				number = GetNumber("Enter a number (0 for stop): ");
			} catch (System.FormatException) {
				Console.WriteLine("Invalid Number enterd.");
				return AskForNumbers();
			} catch (OverflowException) {
				Console.WriteLine("Easy there tiger... Overflow exception.");
				return AskForNumbers();
			}

			if (number == 0)
				Running = false;

			if (number < 0) {
				Console.WriteLine("Greater than 0 please.");
				return AskForNumbers();
			}

			return number;
		}

		public void WriteNumbers(IEnumerable<int> numbers) {
			Console.WriteLine("Server returned numbers");
			Parallel.ForEach(numbers, (number) => { Console.Write(number + " "); });
			Console.Write("\n");
		}

		public async void GetNumbers(int amount, int min, int max, Action<IEnumerable<int>> callback) {
			var result = await mServer.GetNumbersAsync(amount, min, max);
			callback(result);
		}

		private int GetNumber(String text) {
			Console.WriteLine(text);
			return int.Parse(Console.ReadLine());
		}


	}
}
