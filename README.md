# AsyncEventsTest
Async events

This example shows two methods of firing the async event.

	static async Task Main(string[] args)
	{
		TestAsyncEvents test = new TestAsyncEvents();

		test.MyEvent += Test_MyEvent;
		test.MyEvent += Test_MyEvent2;

		Console.WriteLine("# Execute Parallel");
		await test.RunParallel("Parallel");

		Console.WriteLine("");
		Console.WriteLine("# Execute Sequential");
		await test.RunSequential("Sequential");
	}

	private static async Task Test_MyEvent2(object sender, MyEventArgs e)
	{
		Console.WriteLine($"Start of Test_MyEvent 2: {e.Message}");
		await Task.Delay(100);
		Console.WriteLine($"End of Test_MyEvent 2: {e.Message}");
	}

	private static async Task Test_MyEvent(object sender, MyEventArgs e)
	{
		Console.WriteLine($"Start of Test_MyEvent: {e.Message}");
		await Task.Delay(100);
		Console.WriteLine($"End of Test_MyEvent: {e.Message}");
	}
