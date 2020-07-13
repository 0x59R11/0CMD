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
            Draw(obj, CMD.FColor, inNewLine);
        }

        public void Draw(object obj, ConsoleColor color, bool inNewLine = true)
        {
            Draw(obj, color, CMD.BColor, inNewLine);
        }

        public void Draw(object obj, ConsoleColor fColor, ConsoleColor bColor, bool inNewLine = true)
        {
            ConsoleColor lastFColor = CMD.FColor;
            ConsoleColor lastBColor = CMD.BColor;

            CMD.FColor = fColor;
            CMD.BColor = bColor;

            if (inNewLine) { Console.WriteLine(obj); }
            else { Console.Write(obj); }

            CMD.FColor = lastFColor;
            CMD.BColor = lastBColor;
        }


    }
}
