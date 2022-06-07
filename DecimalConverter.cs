namespace BinaryToDecimalConverter;

public class DecimalConverter
{
    public int Convert(string binaryString)
    {
        if (!Validate(binaryString, out var error))
            throw new InvalidDataException(error);

        return ConvertInternal(binaryString);
    }

    public bool TryConvert(string binaryString, out int result)
    {
        result = 0;
        if (!Validate(binaryString, out _))
            return false;

        result = ConvertInternal(binaryString);
        return true;
    }

    private int ConvertInternal(string binaryString)
    {
        int result = 0;
        for (var i = binaryString.Length - 1; i >= 0; i--)
        {
            var value = double.Parse(binaryString.Substring(i, 1));
            result += (int)Math.Pow(value * 2, binaryString.Length - 1 - i);
        }
        return result;
    }

    private bool Validate(string binaryString, out string? error)
    {
        error = null;
        if (binaryString is null || binaryString.Length == 0)
        {
                error = "Can't convert null or empty string";
                return false;
        }

        if (binaryString.Any(value => (byte)value is not 48 or 49))
        {
                error = "Can't convert non-binary string";
                return false;
        }

        return true;
    }
}
