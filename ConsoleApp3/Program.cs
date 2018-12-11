using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
	{
	class Program
		{
		static void Main (string[] args)
			{
			Console.WriteLine(Reverse(153));
			Console.ReadLine();
			}


		public static bool Reverse (int number)
			{
			IEnumerable<int> digits = number.ToString().Select(d => d - '0');
			return digits.Aggregate(0,(s,i) => s + (int)Math.Pow(i,digits.Count())) == number;

			}



		}
	}

