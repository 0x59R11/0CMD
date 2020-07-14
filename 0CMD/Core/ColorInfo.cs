using System;

namespace _0CMD.Core
{
    public struct ColorInfo
    {
        public ConsoleColor F;
        public ConsoleColor B;

        public ColorInfo(ConsoleColor f, ConsoleColor b)
        {
            F = f;
            B = b;
        }
    }
}
