using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the String Calculator");
			Program n = new Program();
			Console.WriteLine("Test numbers seperated by ,");
			Console.WriteLine("Total is: " + n.Add("1,2,5"));
			Console.WriteLine("Total is: " + n.Add("3,6,9"));
			Console.WriteLine("Total is: " + n.Add("3,4,101"));
			Console.WriteLine("Test numbers seperated by new line");
			Console.WriteLine("Total is: " + n.Add("1\n,2,3"));
			Console.WriteLine("Total is: " + n.Add("1,\n2,4"));
			Console.WriteLine("Test empty string");
			Console.WriteLine("Total is: " + n.Add(""));
			Console.WriteLine("Test chosen delimeter");
			Console.WriteLine("Total is: " + n.Add("//$\n1$2$3"));
			Console.WriteLine("Total is: " + n.Add("//^\n4^2^4"));
			Console.WriteLine("Total is: " + n.Add("//*\n5*10*15"));
			Console.WriteLine("Test numbers larger than 1000 are ignored");
			Console.WriteLine("Total is: " + n.Add("2,1001"));
			Console.WriteLine("Total is: " + n.Add("4,10054"));
			Console.WriteLine("Total is: " + n.Add("6,10000000"));
			Console.WriteLine("Test chosen delimeter of arbitrary length");
			Console.WriteLine("Total is: " + n.Add("//%%%%%%%\n1%%%%%%%2%%%%%%%3"));
			Console.WriteLine("Total is: " + n.Add("//&&&\n4&&&5&&&1"));
			Console.WriteLine("Total is: " + n.Add("//(((())))\n3(((())))9(((())))15"));
			Console.WriteLine("Test multiple chosen delimeter");
			Console.WriteLine("Total is: " + n.Add("//%,@\n1%2@3"));
			Console.WriteLine("Total is: " + n.Add("//*,^\n6^7*8"));
			Console.WriteLine("Total is: " + n.Add("//!,)\n9!10)11"));
			Console.WriteLine("Test multiple chosen delimeter of arbitrary length");
			Console.WriteLine("Total is: " + n.Add("//%%%,@@@\n1%%%2@@@3"));
			Console.WriteLine("Total is: " + n.Add("//***,%%%%\n56***1%%%%87"));
			Console.WriteLine("Total is: " + n.Add("//^,$$$$$$$\n40^5$$$$$$$10"));

			Console.ReadLine();
		}

		/* Function: Add
		 * Purpose: To add numbers in a string together
		 * Variables: string number - String a sperated list of numbers to add together
		 */
		public int Add(string number)
		{
			List<string> numberList = new List<string>();
			List<char> delimeterList = new List<char>();
			char[] delimeterArray;
			//Default delimeter we are splitting the string with
			char delimeter = ',';
			//Check if number is longer than 3 Characters
			if (number.Length > 2)
			{
				//Check if number starts with //. If it does we know we are using custom delimeters
				if (number.Substring(0, 2) == "//")
				{
					//Get the index of the // and the \n
					int startPoint = number.IndexOf("//");
					int endPoint = number.IndexOf("\n");
					//Get the custom delimeters and put them in a list
					delimeterArray = number.Substring(startPoint, endPoint - startPoint).ToCharArray();
					delimeterList = delimeterArray.ToList();
					//Split number by the list of delimeters and put it in numbers list
					numberList = number.Split(delimeterList.ToArray(), StringSplitOptions.None).ToList();
				}
				//If the string doesn not start with a // split the list using the default delimeter and put it into number list
				else
				{
					numberList = number.Split(delimeter).ToList();
				}
			}
			else
			{
				numberList = number.Split(delimeter).ToList();
			}

			int total = 0;
			int num = 0;

			for (int i = 0; i < numberList.Count(); i++)
			{
				//Check if the current value is a number
				if (int.TryParse(numberList[i], out int n))
				{
					//If the value is a number set num equal to the current number
					num = int.Parse(numberList[i]);
					//If the number is greater than or 0
					if (num >= 0)
					{
						//If the num is no larger than 1000
						if (num < 1000)
						{
							//Add number to the total
							total += num;
						}
					}
					//if number is less than 0 throw an exception
					else
					{
						throw new Exception("Negatives not allowed");
					}
				}
			}
			//Return the total of the string
			return total;
		}
	}
}
