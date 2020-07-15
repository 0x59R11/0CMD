using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0CMD.Core
{
    public static class CMD
    {
        public delegate void TitleChanged(string title);
        public static event TitleChanged OnTitleChanged;
        
        public static string Title
        {
            get { return Console.Title; }
            set
            {
                Console.Title = value;
                OnTitleChanged?.Invoke(Title);
            }
        }


        #region R
        public delegate void ReadHandle(int read);
        public static event ReadHandle OnRead;

        public delegate void ReadLineHandle(string read);
        public static event ReadLineHandle OnReadLine;

        public delegate void ReadKeyHandle(ConsoleKeyInfo key);
        public static event ReadKeyHandle OnReadKey;


        public static int LastR { get; private set; }
        public static string LastRL { get; private set; }
        public static ConsoleKeyInfo LastRK { get; private set; }


        public static int R()
        {
            return R(true);
        }
        internal static int R(bool on)
        {
            int res = Console.Read();
            OnRead?.Invoke(res);
            LastR = res;
            if (on)
            {
                HISTORY.Add(new HistoryInfo(res, HISTORY.Type.USER));
            }
            return res;
        }

        public static string RL()
        {
            return RL(true);
        }
        public static string RL(bool maybeEmpty = true)
        {
            return RL(maybeEmpty, true);
        }
        internal static string RL(bool maybeEmpty, bool on)
        {
            string res = null;

            if (maybeEmpty)
            {
                res = Console.ReadLine();
            }
            else
            {
                int lastTop = CURSOR.Top;
                int lastLeft = CURSOR.Left;

                while (string.IsNullOrEmpty((res = Console.ReadLine())))
                {
                    CURSOR.SetPosition(lastTop, lastLeft);
                }
            }
            if (on)
            {
                HISTORY.Add(new HistoryInfo(res, HISTORY.Type.USER));
            }
            OnReadLine?.Invoke(res);
            LastRL = res;
            return res;
        }

        public static ConsoleKeyInfo RK()
        {
            return RK(true);
        }
        internal static ConsoleKeyInfo RK(bool on)
        {
            ConsoleKeyInfo res = Console.ReadKey();
            OnReadKey?.Invoke(res);
            LastRK = res;
            if (on)
            {
                HISTORY.Add(new HistoryInfo(res, HISTORY.Type.USER));
            }
            return res;
        }



        #endregion

        public static long EnterKey(ConsoleKey key)
        {
            return EnterKey(key, default);
        }
        public static long EnterKey(ConsoleKey key, ConsoleModifiers modifiers)
        {
            int lastTop = CURSOR.Top;
            int lastLeft = CURSOR.Left;
            
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo info = RK();
                    CURSOR.Top = lastTop;
                    CURSOR.Left = lastLeft;
                    if (info.Key == key && info.Modifiers == modifiers)
                    {
                        stopwatch.Stop();
                        return stopwatch.ElapsedMilliseconds;
                    }
                }
            }
        }



        public static readonly Parser PR = new Parser();
        public static readonly Drawer DW = new Drawer();




        #region DISPLAY
        public static class DISPLAY
        {
            private static Thread displayThread;


            private static int listnerInterval = 25;
            public static int ListnerInterval
            {
                get { return listnerInterval < 0 ? 0 : listnerInterval; }
                set { if (value > 0) { listnerInterval = value; } }
            }


            public delegate void Resized(int newHeight, int newWidth);

            public static event Resized OnWindowResized;
            public static event Resized OnBufferResized;
            public static event Resized OnLargestResized;

            public delegate void ListnerHandle(int wh, int ww, int bh, int bw, int lwh, int lww);
            public static ListnerHandle ListnerCallback;


            public static void StartListner()
            {
                displayThread = new Thread(() =>
                {
                    int lastWH = WH;
                    int lastWW = WW;

                    int lastBH = BH;
                    int lastBW = BW;

                    int lastLWH = LWH;
                    int lastLWW = LWW;

                    while (true)
                    {
                        if (ListnerWResize)
                        {
                            if (lastWH != WH || lastWW != WW)
                            {
                                lastWH = WH;
                                lastWW = WW;
                                OnWindowResized?.Invoke(lastWH, lastWW);
                            }
                        }

                        if (ListnerBResize)
                        {
                            if (lastBH != BH || lastBW != BW)
                            {
                                lastBH = BH;
                                lastBW = BW;
                                OnBufferResized?.Invoke(lastBH, lastBW);
                            }
                        }

                        if (ListnerLWResize)
                        {
                            if (lastLWH != LWH || lastLWW != LWW)
                            {
                                lastLWH = LWH;
                                lastLWW = LWW;
                                OnLargestResized?.Invoke(lastLWH, lastLWW);
                            }
                        }

                        ListnerCallback?.Invoke(lastWH, lastWW, lastBH, lastBW, lastLWH, lastLWW);
                        Thread.Sleep(ListnerInterval);
                    }
                });
                displayThread.Start();
            }
            public static void StopListner()
            {
                displayThread.Abort();
            }



            #region WINDOW
            public static int LastWH { get; private set; }
            public static int LastWW { get; private set; }

            public static bool ListnerWResize { get; set; } = false;

            public static int WH
            {
                get { return Console.WindowHeight; }
                set
                {
                    LastWH = WH;
                    Console.WindowHeight = value;
                }
            }
            public static int WW
            {
                get { return Console.WindowWidth; }
                set
                {
                    LastWW = WW;
                    Console.WindowWidth = value;
                }
            }
            #endregion


            #region BUFFER
            public static int LastBH { get; private set; }
            public static int LastBW { get; private set; }

            public static bool ListnerBResize { get; set; } = false;

            public static int BH
            {
                get { return Console.BufferHeight; }
                set
                {
                    LastBH = BH;
                    Console.BufferHeight = value;
                }
            }
            public static int BW
            {
                get { return Console.BufferWidth; }
                set
                {
                    LastBW = BW;
                    Console.BufferWidth = value;
                }
            }
            #endregion


            #region LARGEST
            public static int LastLWH { get; private set; }
            public static int LastLWW { get; private set; }

            public static bool ListnerLWResize { get; set; } = false;

            public static int LWH
            {
                get { return Console.LargestWindowHeight; }
            }
            public static int LWW
            {
                get { return Console.LargestWindowWidth; }
            }
            #endregion
        }
        #endregion


        #region COLOR
        public static class COLOR
        {
            public delegate void ColorChanged(ConsoleColor newColor);
            
            public static event ColorChanged OnFColorChanged;
            public static event ColorChanged OnBColorChanged;


            
            private static ConsoleColor defaultF = F;
            private static ConsoleColor defaultB = B;

            public static ConsoleColor LastF { get; private set; }
            public static ConsoleColor LastB { get; private set; } 
            
            public static ConsoleColor F
            {
                get { return Console.ForegroundColor; }
                set
                {
                    LastF = F;
                    Console.ForegroundColor = value;
                    OnFColorChanged?.Invoke(F);
                }
            }
            public static ConsoleColor B
            {
                get { return Console.BackgroundColor; }
                set
                {
                    LastB = B;
                    Console.BackgroundColor = value;
                    OnBColorChanged?.Invoke(B);
                }
            }


            public static ColorInfo Current => new ColorInfo(F, B);


            public static void UpdateDefault(ConsoleColor? f, ConsoleColor? b)
            {
                if (f != null)
                {
                    defaultF = f.Value;
                    F = defaultF;
                }
                if (b != null)
                {
                    defaultB = b.Value;
                    B = defaultB;
                }
            }

            public static void Reset()
            {
                F = defaultF;
                B = defaultB;
            }


            public static void Action(Action action, ConsoleColor f, ConsoleColor? b = null)
            {
                if (action == null) { return; }

                ConsoleColor lastF = F;
                ConsoleColor lastB = B;

                F = f;
                if (b != null) { B = b.Value; }

                action.Invoke();

                F = lastF;
                if (b != null) { B = lastB; }
            }
            public static T Func<T>(Func<T> func, ConsoleColor f, ConsoleColor? b = null)
            {
                if (func == null) { return default; }

                ConsoleColor lastF = F;
                ConsoleColor lastB = B;

                F = f;
                if (b != null) { B = b.Value; }

                T result = func.Invoke();

                F = lastF;
                if (b != null) { B = lastB; }
                return result;
            }
        }
        #endregion


        #region CURSOR
        public static class CURSOR
        {
            public delegate void CursorPositionUpdated(int newTop, int newLeft);

            public static event CursorPositionUpdated OnCursorPositionUpdated;

            
            public static int LastTop { get; private set; }
            public static int LastLeft { get; private set; }


            public static int Top
            {
                get { return Console.CursorTop; }
                set
                {
                    LastTop = Top;
                    Console.CursorTop = value;
                }
            }

            public static int Left
            {
                get { return Console.CursorLeft; }
                set
                {
                    LastLeft = Left;
                    Console.CursorLeft = value;
                }
            }

            public static int Size
            {
                get { return Console.CursorSize; }
                set { Console.CursorSize = value; }
            }

            public static bool Visible
            {
                get { return Console.CursorVisible; }
                set { Console.CursorVisible = value; }
            }


            public static CursorInfo Current => new CursorInfo(Top, Left, Size, Visible);



            public static void Set(CursorInfo info)
            {
                Top = info.Top;
                Left = info.Left;
                Size = info.Size;
                Visible = info.Visible;
            }

            public static void SetPosition(int top, int left)
            {
                Top = top;
                Left = left;
                OnCursorPositionUpdated?.Invoke(Top, Left);
            }
        }
        #endregion


        #region HISTORY
        public static class HISTORY
        {
            public delegate void Added(HistoryInfo info);

            public static event Added OnAdded;
            
            
            public static readonly List<HistoryInfo> Info = new List<HistoryInfo>();

            public static bool On { get; set; } = true;
            public static HistoryInfo Last { get; private set; }
            public static int Count => Info.Count;


            public static void Add(HistoryInfo info)
            {
                if (On)
                {
                    Info.Add((Last = info));
                    OnAdded?.Invoke(Last);
                }
            }

            public static void Clear()
            {
                Last = default;
                Info.Clear();
            }


            public enum Type
            {
                USER,
                CLIENT,
            }
        }
        #endregion
    }
}
