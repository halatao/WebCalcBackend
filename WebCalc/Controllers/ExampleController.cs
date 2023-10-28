using Microsoft.AspNetCore.Mvc;
using WebCalc.Api;
using WebCalc.Services;

namespace WebCalc.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExampleController : Controller
{
    private readonly ExampleService _exampleService;

    public ExampleController(ExampleService exampleService)
    {
        _exampleService = exampleService;
    }

    [HttpPost("CreateExample")]
    public async Task<IActionResult> CreateExample([FromBody] ExampleDto exampleDto)
    {
        try
        {
            return Ok(await _exampleService.CreateExampleAsync(exampleDto));
        }
        catch (Exception ex)
        {
            ExceptionService.CreateException(ex);
        }

        return BadRequest();
    }

    [HttpGet("GetLastTenCalculations")]
    public async Task<IActionResult> GetLastTenCalculations()
    {
        try
        {
            return Ok(await _exampleService.GetLastTenCalculationsAsync());
        }
        catch (Exception ex)
        {
            ExceptionService.CreateException(ex);
        }

        return BadRequest();
    }
}