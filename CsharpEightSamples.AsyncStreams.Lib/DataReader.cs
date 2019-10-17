using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEightSamples.AsyncStreams.Lib
{
    public class DataReader : IDisposable
    {
        private int count;

        public DataConnection Connection { get; }

        public DataReader(DataConnection connection)
        {
            Connection = connection;
            Console.WriteLine("Data reader created");
        }

        public bool HasMore => count < 20;

        public async Task<int> ReadNext()
        {
            // every 3 elements, wait 3 seconds:
            if (count % 3 == 0)
                await Task.Delay(3000);           

            return count++;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Data reader disposed");
        }

    }
}
