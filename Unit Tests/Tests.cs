using NUnit.Framework;

namespace SimulationCarApp
{
	[TestFixture]
	public class SimulationCarTests
	{
		private AutoDrivingCar _carObj;

		[SetUp]
		public void SetUp()
		{
			_carObj = new AutoDrivingCar(10,10,1,2,'N');
		}

		[Test]
		public void TestMove()
		{
			_carObj.Move();

			Assert.AreEqual(3, _carObj.Y);
		}

		[Test]
		public void TestRotateLeft()
		{

			_carObj.RotateLeft('N');

			Assert.AreEqual('W',_carObj.Direction);
		}

		[Test]
		public void TestRotateRight()
		{
			_carObj.RotateRight('N');

			Assert.AreEqual('E', _carObj.Direction);
		}

		[Test]
		public void TestExecuteCommands()
		{
			_carObj.ExecuteCommands("FFRFFFRRLF");

			Assert.AreEqual("4 3 S", _carObj.ToString());
		}
	}
}
