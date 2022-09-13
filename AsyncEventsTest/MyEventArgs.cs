using System;
using System.Text;
using System.Threading.Tasks;

namespace AsyncEventsTest
{
    public class MyEventArgs : EventArgs
    {
        public MyEventArgs(string message)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public string Message { get; }
    }
}
