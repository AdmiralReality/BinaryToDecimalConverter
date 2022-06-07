using BinaryToDecimalConverter;

DecimalConverter converter = new();
if (args.Length == 0)
{
    GreetRealtime();

    string? input;
    do
    {
        input = Console.ReadLine();
        converter.Convert(input);
    }
    while (input?.ToUpper() != "QUIT");
}
else
{
    GreetArgs();

    foreach (var str in args)
    {
        if (converter.TryConvert(str, out var result))
            Console.WriteLine($"{str} => {result}");
        else
            Console.WriteLine($"{str} is invalid");
    }
}

void GreetRealtime()
{
    string text = "Binary to decimal converter application. Input decimal number " +
        "(number, based binary system, containing only \"0\" and \"1\"). Type \"quit\" to exit. " +
        "Application also supports running with \"args\".";
    Console.WriteLine(text);
}

void GreetArgs()
{
    string text = "Binary to decimal converter. Running on values provided with \"args\". " +
        "Application also supports realtime mode if you run it with empty \"args\".\n\n" + 
        "{binary} => {decimal}";
    Console.WriteLine(text);
}