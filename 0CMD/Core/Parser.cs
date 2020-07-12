using _0CMD.API;
using System;
using System.Collections.Generic;
using System.Linq;
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
            bool result = false;
            uint attempts = 0;
            result = CMD.FuncWithColor(() =>
            {
                while (true)
                {
                    CMD.Draw("> ", ConsoleColor.Yellow, false);
                    CMD.Draw(title, titleColor ?? CMD.FColor, false);
                    string input = null;
                    if (bool.TryParse((input = CMD.RL()), out bool output))
                    {
                        if (func != null)
                        {
                            if (func.Invoke(output, input) == true)
                            {
                                return output;
                            }
                            else
                            {
                                CMD.Draw(string.Format(error, ++attempts, input, output), ConsoleColor.Red, true);
                            }
                        }
                        else
                        {
                            return output;
                        }
                    }
                    else
                    {
                        CMD.Draw(string.Format(error, ++attempts, input, input), ConsoleColor.Red, true);
                    }
                }
            }, inputColor ?? CMD.FColor, null);
            return result;
        }


        public byte ParseByte(string title = "Enter byte: ", string error = "[{0}] Error: {1}", Func<byte, string, bool> func = null, ConsoleColor? titleColor = null, ConsoleColor? inputColor = null)
        {
            byte result = 0;
            uint attempts = 0;
            result = CMD.FuncWithColor(() =>
            {
                while (true)
                {
                    CMD.Draw("> ", ConsoleColor.Yellow, false);
                    CMD.Draw(title, titleColor ?? CMD.FColor, false);
                    string input = null;
                    if (byte.TryParse((input = CMD.RL()), out byte output))
                    {
                        if (func != null)
                        {
                            if (func.Invoke(output, input) == true)
                            {
                                return output;
                            }
                            else
                            {
                                CMD.Draw(string.Format(error, ++attempts, input, output));
                            }
                        }
                        else
                        {
                            return output;
                        }
                    }
                    else
                    {
                        CMD.Draw(string.Format(error, ++attempts, input, output));
                    }
                }
            }, inputColor ?? CMD.FColor, null);
            return result;
        }
    }
}
