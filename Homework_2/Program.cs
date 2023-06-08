while (true)
{
    Console.WriteLine("Enter a digit between 1 and 6 to run the following tasks:\n" +
                      "1 - RectangleArea\n" +
                      "2 - TriangleArea\n" +
                      "3 - Calculator\n" +
                      "4 - IsAdult\n" +
                      "5 - Temperature\n" +
                      "6 - Season\n" +
                      "0 - Exit the application");
    var input = Console.ReadLine();
    switch (input)
    {
        case "0":
            Environment.Exit(0);
            break;
        case "1":
            RectangleArea();
            break;
        case "2":
            TriangleArea();
            break;
        case "3":
            Calculator();
            break;
        case "4":
            IsAdult();
            break;
        case "5":
            Temperature();
            break;
        case "6":
            Season();
            break;
        default:
            Console.WriteLine("Error! Enter a number between 1 and 6 or 0 to exit.");
            break;
    }
}

int GetInt(string message)
{
    var isCorrect = false;
    var num = 0;
    while (!isCorrect)
    {
        isCorrect = true;
        Console.WriteLine(message);
        try
        {
            num = int.Parse(Console.ReadLine()!);
        }
        catch (Exception)
        {
            Console.WriteLine("Error! Enter integer number!");
            isCorrect = false;
        }
    }
    return num;
}

int GetChar(string message, IReadOnlySet<char> charSet)
{
    var isCorrect = false;
    var character = '\0';
    while (!isCorrect)
    {
        isCorrect = true;
        Console.WriteLine(message);
        try
        {
            character = char.Parse(Console.ReadLine()!);
        }
        catch (Exception)
        {
            Console.WriteLine("Error! Enter integer number!");
            isCorrect = false;
        }
        if (!charSet.Contains(character))
        {
            Console.WriteLine("Error! Char has to be one of the following symbols:" + string.Join(",", charSet));
            isCorrect = false;
        }
    }
    return character;
}

void RectangleArea()
{
    var side1 = GetInt("Enter first side of the rectangle:");
    var side2 = GetInt("Enter second side of the rectangle:");
    Console.WriteLine("Area of the rectangle = " + side1 * side2);
}

void TriangleArea()
{
    var side1 = GetInt("Enter first side of the triangle:");
    var side2 = GetInt("Enter second side of the triangle:");
    Console.WriteLine("Area of the rectangle = " + (double)side1 * side2 / 2);
}
void Calculator()
{
    var num1 = GetInt("Enter first number:");
    var operation = GetChar("Enter operation (+ - * / %):", new HashSet<char>{'+', '-', '*', '/', '%'});
    var num2 = GetInt("Enter second number:");

    double result = operation switch
    {
        '+' => num1 + num2,
        '-' => num1 - num2,
        '*' => num1 * num2,
        '/' => num1 / num2,
        '%' => num1 % num2,
        _ => 0
    };

    Console.WriteLine($"the result is {result}");
}

void IsAdult()
{
    var age = GetInt("Enter age:");
    Console.WriteLine(age < 18 ? "Isn't an adult" : "Is an adult");
}

void Temperature()
{
    var temperature = GetInt("Enter temperature:");
    var result = temperature switch
    {
        < 0 => "Very cold",
        >= 0 and < 10 => "Cold",
        >= 10 and < 20 => "Average",
        >= 20 and < 30 => "Warm",
        >= 30 => "Hot"
    };

    Console.WriteLine(result);
}

void Season()
{
    Console.WriteLine("Enter a month (English, first capital letter):");
    var month = Console.ReadLine();

    switch (month)
    {
        case ("December") or ("January") or ("February"):
            Console.WriteLine("Winter");
            break;

        case ("March") or ("April") or ("May"):
            Console.WriteLine("Spring");
            break;

        case ("June") or ("July") or ("August"):
            Console.WriteLine("Summer");
            break;

        case ("September") or ("October") or ("November"):
            Console.WriteLine("Autumn");
            break;

        default:
            Console.WriteLine("Incorrect month name");
            break;
    }
}