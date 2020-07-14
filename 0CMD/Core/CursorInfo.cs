namespace _0CMD.Core
{
    public struct CursorInfo
    {
        public int Top;
        public int Left;
        public int Size;
        public bool Visible;

        public CursorInfo(int top, int left, int size, bool visible)
        {
            Top = top;
            Left = left;
            Size = size;
            Visible = visible;
        }
    }
}
