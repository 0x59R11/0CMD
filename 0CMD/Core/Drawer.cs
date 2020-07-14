using _0CMD.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0CMD.Core
{
    public class Drawer : IDrawer
    {
        public void Draw(object obj)
        {
            Draw(obj, true);
        }

        public void Draw(object obj, bool inNewLine = true)
        {
            Draw(obj, CMD.COLOR.F, inNewLine);
        }

        public void Draw(object obj, ConsoleColor color, bool inNewLine = true)
        {
            Draw(obj, color, CMD.COLOR.B, inNewLine);
        }

        public void Draw(object obj, ConsoleColor fColor, ConsoleColor bColor, bool inNewLine = true)
        {
            ConsoleColor lastFColor = CMD.COLOR.F;
            ConsoleColor lastBColor = CMD.COLOR.B;

            CMD.COLOR.F = fColor;
            CMD.COLOR.B = bColor;

            if (inNewLine) { Console.WriteLine(obj); }
            else { Console.Write(obj); }
            if (!string.IsNullOrEmpty(obj?.ToString()))
            {
                CMD.HISTORY.Add(new HistoryInfo(obj, CMD.HISTORY.Type.CLIENT));
            }

            CMD.COLOR.F = lastFColor;
            CMD.COLOR.B = lastBColor;
        }
    }
}
