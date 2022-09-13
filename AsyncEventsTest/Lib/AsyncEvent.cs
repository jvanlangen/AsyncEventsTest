using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncEventsTest
{
    public delegate Task EventHandlerAsync<T>(object sender, T e) where T : EventArgs;

    public class AsyncEvent<T> where T : EventArgs
    {
        private readonly List<EventHandlerAsync<T>> _invocationList = new List<EventHandlerAsync<T>>();

        public void Clear(EventHandlerAsync<T> handler) =>
            _invocationList.Clear();

        public void Add(EventHandlerAsync<T> handler) =>
            _invocationList.Add(handler);

        public void Remove(EventHandlerAsync<T> handler) =>
            _invocationList.Remove(handler);

        public async Task RaiseSequential(object sender, T e)
        {
            foreach (var handler in _invocationList)
                await handler(sender, e);
        }

        public Task RaiseParallel(object sender, T e) =>
            Task.WhenAll(_invocationList.Select(handler => handler(sender, e)));
    }

}
