using System.Threading.Tasks;

namespace AsyncEventsTest
{
    public class TestAsyncEvents
    {
        private readonly AsyncEvent<MyEventArgs> _myEvent = new AsyncEvent<MyEventArgs>();

        public event EventHandlerAsync<MyEventArgs> MyEvent
        {
            add => _myEvent.Add(value);
            remove => _myEvent.Remove(value);
        }

        internal Task RunSequential(string message) =>
            _myEvent.RaiseSequential(this, new MyEventArgs(message));

        internal Task RunParallel(string message) =>
            _myEvent.RaiseParallel(this, new MyEventArgs(message));
    }

}
