using System;

namespace _0CMD.Core
{
    public struct HistoryInfo
    {
        public object Content;
        public CMD.HISTORY.Type Type;
        public DateTime Date;
        public CursorInfo Cursor;
        public ColorInfo Color;

        public HistoryInfo(object content, CMD.HISTORY.Type type)
        {
            Content = content;
            Type = type;
            Date = DateTime.Now;
            Cursor = CMD.CURSOR.Current;
            Color = CMD.COLOR.Current;
        }
    }
}
