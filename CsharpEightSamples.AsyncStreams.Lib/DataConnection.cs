using System;

namespace CsharpEightSamples.AsyncStreams.Lib
{
    public class DataConnection : IDisposable
    {
        public DataConnection()
        {
            Console.WriteLine("Data connection created");
        }

        public DataReader CreateReader()
        {
            return new DataReader(this);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Data connection disposed");
        }
    }
}
