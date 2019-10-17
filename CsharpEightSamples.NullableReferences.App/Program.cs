using CsharpEightSamples.NullableReferences.Lib;
using System;

namespace CsharpEightSamples.NullableReferences.App
{
    static class Program
    {
        static void Main(string[] args)
        {
            Person miguel = new Person("Miguel", "de Icaza");
            var length = GetLengthOfMiddleName(miguel);
            Console.WriteLine(length);

            Console.ReadKey();
        }

        private static int GetLengthOfMiddleName(Person p)
        {
            string middleName = p.MiddleName;

            return middleName.Length;
        }

    }
}
