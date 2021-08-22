using System;

namespace Frankenstein_BOT
{
    class Program
    {
        static void Main(string[] args)
        {
            new Bot().MainAsync().GetAwaiter().GetResult();
        }
    }
}
