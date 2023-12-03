using System;
using System.Linq;

namespace SimulationCarApp
{
	public class Program
	{
		static string commands;
		static int x = 0, y = 0;
		static char direction = char.MinValue;
		static void Main()
		{
			var validInput = false;
			Console.WriteLine("Enter the width and height of the field (Format should be e.g. 10 10)");
			int width = 0, height = 0;
			string[] dimensions;
			string inputDimensions = Console.ReadLine();

			while (!validInput)
			{
				dimensions = inputDimensions.Split();
				if (dimensions.Length == 2 && int.TryParse(dimensions[0], out int outWidth) && int.TryParse(dimensions[1], out int outHeight) && outWidth > 0 && outHeight > 0)
				{
					validInput = true;
					width = outWidth;
					height = outHeight;
				}
				else
				{
					Console.WriteLine("Invalid input! Please enter the width and height in correct format. ");
					inputDimensions = Console.ReadLine();
				}
			}

			GetStartPositions();

			commands = GetCommands();

			AutoDrivingCar car = new AutoDrivingCar(width, height, x, y, direction);

			car.ExecuteCommands(commands);

			Console.WriteLine(car.ToString());
			Console.ReadKey();
		}

		static void GetStartPositions()
		{
			var validInput = false;

			Console.WriteLine("Enter the current position and facing direction of the car (e.g. 1 2 N)");
			string inputCarPosition = Console.ReadLine();
			string[] startPosition;

			while (!validInput)
			{
				startPosition = inputCarPosition.Split();
				if (startPosition.Length == 3 && int.TryParse(startPosition[0], out int outX) && int.TryParse(startPosition[1], out int outY) && char.TryParse(startPosition[2], out char outPosition))
				{
					validInput = true;
					x = outX;
					y = outY;
					direction = outPosition;
				}
				else
				{
					Console.WriteLine("Invalid input! Please enter the current position and facing  direction of the car. ");
					inputCarPosition = Console.ReadLine();
				}
			}
		}

		static string GetCommands()
		{
			var validInput = false;

			Console.WriteLine("Enter the subsequent commands you want car to execute (e.g. FFRFFFRRLF)");
			string commands = Console.ReadLine();

			while (!validInput)
			{
				if (commands.Length > 0 && !commands.Any(char.IsDigit))
				{
					validInput = true;
					continue;
				}
				else
				{
					Console.WriteLine("Invalid input! Please enter the correct commands containing only alphabets. ");
					commands = Console.ReadLine();
				}
			}

			return commands;
		}
	}
}




