# AsyncEvents

This simple example shows two methods of firing the async event. 
- The parallel version triggers the handlers and waits until all are completed. Meaning that when async is used in handlers, some parts may be executed parallel.
- The sequential version triggers the handler one by one and waits until each handler is completed before triggering the next handler.

NOTE!: The exception handling is different per method. The sequential version is closes to the non-async events handling. (that's because each handler is awaited separately before the next is fired and the whole execution is terminated when one throws an exception.)

```cs
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
```

Results:

```
# Execute Parallel
Start of Test_MyEvent: Parallel
Start of Test_MyEvent 2: Parallel
End of Test_MyEvent 2: Parallel
End of Test_MyEvent: Parallel

# Execute Sequential
Start of Test_MyEvent: Sequential
End of Test_MyEvent: Sequential
Start of Test_MyEvent 2: Sequential
End of Test_MyEvent 2: Sequential
```

It would be great when such async would be implemented in UI frameworks like WPF/WinForms. This way a button click is able to handle exceptions in async code much better.
