namespace SimulationCarApp
{
	public class AutoDrivingCar
	{
		public int Width { get; }
		public int Height { get; }
		public int X { get; private set; }
		public int Y { get; private set; }
		public char Direction { get; private set; }

		public AutoDrivingCar(int width, int height, int x, int y, char direction)
		{
			Width = width;
			Height = height;
			X = x;
			Y = y;
			Direction = direction;
		}

		public void Move()
		{
			if (Direction == 'N' && Y < Height - 1)
				Y++;
			else if (Direction == 'S' && Y > 0)
				Y--;
			else if (Direction == 'E' && X < Width - 1)
				X++;
			else if (Direction == 'W' && X > 0)
				X--;
		}

		public void RotateLeft(char direction)
		{
			switch (direction)
			{
				case 'N':
					Direction = 'W';
					break;
				case 'S':
					Direction = 'E';
					break;
				case 'E':
					Direction = 'N';
					break;
				case 'W':
					Direction = 'S';
					break;
				default:
					Direction = direction;
					break;

			}
		}

		public void RotateRight(char direction)
		{
			switch (direction)
			{
				case 'N':
					Direction = 'E';
					break;
				case 'S':
					Direction = 'W';
					break;
				case 'E':
					Direction = 'S';
					break;
				case 'W':
					Direction = 'N';
					break;
				default:
					Direction = direction;
					break;

			}
		}

		public void ExecuteCommands(string commands)
		{
			foreach (char command in commands)
			{
				if (command == 'F')
					Move();
				else if (command == 'L')
					RotateLeft(Direction);
				else if (command == 'R')
					RotateRight(Direction);
			}
		}

		public override string ToString()
		{
			return $"{X} {Y} {Direction}";
		}
	}

}
