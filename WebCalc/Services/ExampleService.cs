using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebCalc.Api;
using WebCalc.Data;
using WebCalc.Models;

namespace WebCalc.Services;

public class ExampleService
{
    private readonly WebCalcContext _context;

    public ExampleService(WebCalcContext context)
    {
        _context = context;
    }

    public async Task<Example?> CreateExampleAsync(ExampleDto example)
    {
        var calc = new Example
        {
            FirstNumber = example.FirstNumber,
            SecondNumber = example.SecondNumber,
            Operation = example.Operation,
            Result = CalculationService.Calculate(example)
        };

        _context.Add(calc);

        await _context.SaveChangesAsync();

        return calc;
    }

    public async Task<List<Example>> GetLastTenCalculationsAsync()
    {
        return await (_context.Examples ?? throw new InvalidOperationException("_context.Examples is null"))
            .OrderByDescending(q => q.Id)
            .Take(10)
            .ToListAsync();
    }
}