using System;
using OpenAL;

namespace Examples
{
    public static class ContextCreation
    {
        public static void Main(string[] args)
        {
            var device = Alc.OpenDevice(null);
            var context = Alc.CreateContext(device, null);

            Console.WriteLine(Alc.MakeContextCurrent(context));
        }
    }
}