using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _0CMD.Core
{
    public static class CMD
    {
        public static readonly Parser PR = new Parser();
        public static readonly Drawer DW = new Drawer();


        /// <summary>
        /// Заголосок консоли
        /// </summary>
        public static string Title
        {
            get { return Console.Title; }
            set { Console.Title = value; }
        }


        #region CONSOLE-COLOR

        private static ConsoleColor defaultFColor = Console.ForegroundColor;
        private static ConsoleColor defaultBColor = Console.BackgroundColor;

        public static bool UpdateFDefaultColor { get; set; } = false;
        public static bool UpdateBDefaultColor { get; set; } = false;


        public static ConsoleColor LastFColor { get; private set; }
        public static ConsoleColor LastBColor { get; private set; }



        /// <summary>
        /// Цвет текста консоли
        /// </summary>
        public static ConsoleColor FColor
        {
            get { return Console.ForegroundColor; }
            set
            {
                LastFColor = FColor;
                Console.ForegroundColor = value;
                if (UpdateFDefaultColor) { defaultFColor = value; }
            }
        }

        /// <summary>
        /// Цвет текста поумолчание
        /// </summary>
        public static ConsoleColor DefaultFColor
        {
            get { return defaultFColor; }
            set
            {
                defaultFColor = value;
                FColor = value;
            }
        }
        


        /// <summary>
        /// Цвет фона консоли
        /// </summary>
        public static ConsoleColor BColor
        {
            get { return Console.BackgroundColor; }
            set
            {
                LastBColor = BColor;
                Console.BackgroundColor = value;
                if (UpdateBDefaultColor) { defaultBColor = value; }
            }
        }

        /// <summary>
        /// Цвет фона поумолчание
        /// </summary>
        public static ConsoleColor DefaultBColor
        {
            get { return defaultBColor; }
            set
            {
                defaultBColor = value;
                BColor = value;
            }
        }


        public static void ResetColor()
        {
            FColor = defaultFColor;
            BColor = defaultBColor;
        }



        public static void ActionWithColor(Action action, ConsoleColor fColor, ConsoleColor? bColor = null)
        {
            if (action == null) { return; }
            ConsoleColor lastFColor = FColor;
            ConsoleColor lastBColor = BColor;

            FColor = fColor;
            if (bColor != null) { BColor = bColor.Value; }

            action.Invoke();

            FColor = lastFColor;
            if (bColor != null) { BColor = lastBColor; }
        }

        public static T FuncWithColor<T>(Func<T> func, ConsoleColor fColor, ConsoleColor? bColor = null)
        {
            if (func == null) { return default; }
            ConsoleColor lastFColor = FColor;
            ConsoleColor lastBColor = BColor;

            FColor = fColor;
            if (bColor != null) { BColor = bColor.Value; }

            T result = func.Invoke();

            FColor = lastFColor;
            if (bColor != null) { BColor = lastBColor; }  
            return result;
        }




        #endregion

        #region CONSOLE-READKEY
        public static ConsoleKeyInfo RK()
        {
            return Console.ReadKey();
        }

        public static long EnterKey(ConsoleKey key)
        {
            return EnterKey(key, default);
        }
        public static long EnterKey(ConsoleKey key, ConsoleModifiers modifiers)
        {
            int lastHorizontalPosition = Cursor.Horizontal;
            int lastVerticalPosition = Cursor.Vertical;
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo info = RK();
                    Cursor.Horizontal = lastHorizontalPosition;
                    Cursor.Vertical = lastVerticalPosition;
                    if (info.Key == key && info.Modifiers == modifiers)
                    {
                        stopwatch.Stop();
                        return stopwatch.ElapsedMilliseconds;
                    }
                }
            }
        }
        #endregion


        public static string RL()
        {
            return Console.ReadLine();
        }




        /// <summary>
        /// Курсор консоли
        /// </summary>
        public static class Cursor
        {
            /// <summary>
            /// Положение курсора по Вертикали
            /// </summary>
            public static int Vertical
            {
                get { return Console.CursorTop; }
                set { Console.CursorTop = value; }
            }

            /// <summary>
            /// Положение курсова по Горизонтали
            /// </summary>
            public static int Horizontal
            {
                get { return Console.CursorLeft; }
                set { Console.CursorLeft = value; }
            }

            /// <summary>
            /// Размер курсора
            /// </summary>
            public static int Size
            {
                get { return Console.CursorSize; }
                set { Console.CursorSize = value; }
            }

            /// <summary>
            /// Видимость курсова
            /// </summary>
            public static bool Visible
            {
                get { return Console.CursorVisible; }
                set { Console.CursorVisible = value; }
            }


            /// <summary>
            /// Изменить позицию курсова
            /// </summary>
            /// <param name="vertical"> По вертикали </param>
            /// <param name="horizontal"> По горизонтали </param>
            public static void SetPosition(int vertical, int horizontal)
            {
                Vertical = vertical;
                Horizontal = horizontal;
            }
        }
    }
}
