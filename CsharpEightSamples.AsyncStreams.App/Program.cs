using CsharpEightSamples.AsyncStreams.Lib;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsharpEightSamples.AsyncStreams.App
{
    static class Program
    {
        static async Task Main()
        {
            await foreach (var number in ReadData())
            {
                Console.WriteLine($"The time is {DateTime.Now:hh:mm:ss}. Retrieved {number}");
            }
        }

        internal static async IAsyncEnumerable<int> ReadData()
        {
            using (var connection = new DataConnection())
            {
                using (var reader = connection.CreateReader())
                {
                    while(reader.HasMore)
                    {
                        yield return await reader.ReadNext();
                    }
                }
            }
        }

        internal static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                // every 3 elements, wait 3 seconds:
                if (i % 3 == 0)
                    await Task.Delay(3000);
                yield return i;
            }
        }
    }
}
