using _0CMD.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _0CMD.Core
{
    public class Parser : IParser
    {
        public bool ParseBool(object obj)
        {
            return bool.Parse(obj.ToString());
        }


        public byte ParseByte(object obj)
        {
            return byte.Parse(obj.ToString());
        }
        public sbyte ParseSByte(object obj)
        {
            return sbyte.Parse(obj.ToString());
        }


        public short ParseShort(object obj)
        {
            return short.Parse(obj.ToString());
        }
        public ushort ParseUshort(object obj)
        {
            return ushort.Parse(obj.ToString());
        }


        public int ParseInt(object obj)
        {
            return int.Parse(obj.ToString());
        }
        public uint ParseUint(object obj)
        {
            return uint.Parse(obj.ToString());
        }


        public long ParseLong(object obj)
        {
            return long.Parse(obj.ToString());
        }
        public ulong ParseUlong(object obj)
        {
            return ulong.Parse(obj.ToString());
        }


        public float ParseFloat(object obj)
        {
            return float.Parse(obj.ToString());
        }


        public double ParseDouble(object obj)
        {
            return double.Parse(obj.ToString());
        }


        public decimal ParseDecimal(object obj)
        {
            return decimal.Parse(obj.ToString());
        }



        public char ParseChar(object obj)
        {
            return char.Parse(obj.ToString());
        }

        public string ParseString(object obj)
        {
            return obj.ToString();
        }




        public bool ParseBool(string title = "Enter bool: ", string error = "[{0}] Error: {1}", Func<bool, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = bool.TryParse(s, out bool r); return (b, r);
            }, func, titleColor, inputColor);
        }


        public byte ParseByte(string title = "Enter byte: ", string error = "[{0}] Error: {1}", Func<byte, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = byte.TryParse(s, out byte r); return (b, r);
            }, func, titleColor, inputColor);
        }
        public sbyte ParseSByte(string title = "Enter sbyte: ", string error = "[{0}] Error: {1}", Func<sbyte, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = sbyte.TryParse(s, out sbyte r); return (b, r);
            }, func, titleColor, inputColor);
        }


        public short ParseShort(string title = "Enter short: ", string error = "[{0}] Error: {1}", Func<short, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = short.TryParse(s, out short r); return (b, r);
            }, func, titleColor, inputColor);
        }
        public ushort ParseUshort(string title = "Enter ushort: ", string error = "[{0}] Error: {1}", Func<ushort, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = ushort.TryParse(s, out ushort r); return (b, r);
            }, func, titleColor, inputColor);
        }


        public int ParseInt(string title = "Enter int: ", string error = "[{0}] Error: {1}", Func<int, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = int.TryParse(s, out int r); return (b, r);
            }, func, titleColor, inputColor);
        }
        public uint ParseUint(string title = "Enter uint: ", string error = "[{0}] Error: {1}", Func<uint, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = uint.TryParse(s, out uint r); return (b, r);
            }, func, titleColor, inputColor);
        }


        public long ParseLong(string title = "Enter long: ", string error = "[{0}] Error: {1}", Func<long, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = long.TryParse(s, out long r); return (b, r);
            }, func, titleColor, inputColor);
        }
        public ulong ParseUlong(string title = "Enter ulong: ", string error = "[{0}] Error: {1}", Func<ulong, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = ulong.TryParse(s, out ulong r); return (b, r);
            }, func, titleColor, inputColor);
        }


        public float ParseFloat(string title = "Enter float: ", string error = "[{0}] Error: {1}", Func<float, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = float.TryParse(s, out float r); return (b, r);
            }, func, titleColor, inputColor);
        }
        
        public double ParseDouble(string title = "Enter double: ", string error = "[{0}] Error: {1}", Func<double, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = double.TryParse(s, out double r); return (b, r);
            }, func, titleColor, inputColor);
        }

        public decimal ParseDecimal(string title = "Enter decimal: ", string error = "[{0}] Error: {1}", Func<decimal, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = decimal.TryParse(s, out decimal r); return (b, r);
            }, func, titleColor, inputColor);
        }


        public char ParseChar(string title = "Enter char: ", string error = "[{0}] Error: {1}", Func<char, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                bool b = char.TryParse(s, out char r); return (b, r);
            }, func, titleColor, inputColor);
        }
        public string ParseString(string title = "Enter string: ", string error = "[{0}] Error: {1}", Func<string, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            return Parse(title, error, (s) =>
            {
                return (true, s);
            }, func, titleColor, inputColor);
        }


        private T Parse<T>(string title, string error, Func<string, (bool, T)> answerCallback = null, Func<T, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            uint attempts = 0;
            return CMD.COLOR.Func(() =>
            {
                while (true)
                {
                    CMD.DW.Draw("> ", ConsoleColor.Yellow, false);
                    CMD.DW.Draw(title, titleColor ?? CMD.COLOR.F, false);

                    string input = null;
                    (bool isTrue, T value) answer = answerCallback.Invoke((input = CMD.RL()));
                    if (answer.isTrue)
                    {
                        if (func != null)
                        {
                            if (func.Invoke(answer.value, input))
                            {
                                return answer.value;
                            }
                            else
                            {
                                CMD.DW.Draw(string.Format(error, ++attempts, input, answer.value), ConsoleColor.Red, true);
                            }
                        }
                        else
                        {
                            return answer.value;
                        }
                    }
                    else
                    {
                        CMD.DW.Draw(string.Format(error, ++attempts, input, answer.value), ConsoleColor.Red, true);
                    }
                }
            }, inputColor ?? CMD.COLOR.F, null);
        }
    }
}
