using Microsoft.AspNetCore.Mvc;
using WebApiFizzBuzz.Application;

namespace WebApiFizzBuzz.DistributedServices;
[Route("api/[controller]")]
[ApiController]
public class FizzBuzzController : ControllerBase
{
    private readonly IFizzBuzzService _fizzBuzzService;
   private readonly ILogger<FizzBuzzController> _logger;


    public FizzBuzzController(IFizzBuzzService fizzBuzzService, ILogger<FizzBuzzController> logger)
    {
        _fizzBuzzService = fizzBuzzService;
         _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<string>>> GetFizzBuzzSeries(int randomNumber, int limit)
    {
        try
        {
            var series = await _fizzBuzzService.GetFizzBuzzSeriesAsync(randomNumber, limit);
            return Ok(series);
        }
        catch (System.Exception ex)
        { 
           
            // Log the error using NLog
             _logger.LogError(ex, "Error generating Fizz Buzz series");
            return StatusCode(500, "An error occurred while generating the Fizz Buzz series");
        }
    }
}