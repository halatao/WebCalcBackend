using WebCalc.Api;

namespace WebCalc.Services;

public class CalculationService
{
    public static double Calculate(ExampleDto exampleDto)
    {
        var operation = exampleDto.Operation;
        var firstNumber = exampleDto.FirstNumber;
        var secondNumber = exampleDto.SecondNumber;
        var result = operation switch
        {
            "+" => firstNumber + secondNumber,
            "-" => firstNumber - secondNumber,
            "*" => firstNumber * secondNumber,
            "/" => firstNumber / secondNumber,
            _ => throw new Exception("Invalid operation")
        };
        return exampleDto.RealNum ? result : Math.Round(result);
    }
}