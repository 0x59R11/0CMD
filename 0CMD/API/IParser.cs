namespace _0CMD.API
{
    public interface IParser
    {
        bool ParseBool(object obj);
        

        byte ParseByte(object obj);
        sbyte ParseSByte(object obj);


        short ParseShort(object obj);
        ushort ParseUshort(object obj);


        int ParseInt(object obj);
        uint ParseUint(object obj);


        long ParseLong(object obj);
        ulong ParseUlong(object obj);


        float ParseFloat(object obj);


        double ParseDouble(object obj);


        decimal ParseDecimal(object obj);


        char ParseChar(object obj);
        string ParseString(object obj);
    }
}
