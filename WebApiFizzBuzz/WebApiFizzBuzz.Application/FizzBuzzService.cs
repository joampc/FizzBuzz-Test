
using Microsoft.AspNetCore.Mvc;
using WebApiFizzBuzz.Domain;


namespace WebApiFizzBuzz.Application;
public interface IFizzBuzzService
{
    Task<List<string>> GetFizzBuzzSeriesAsync(int randomNumber, int limit);
}

public class FizzBuzzService : IFizzBuzzService
{
    private readonly IFizzBuzzRepository _fizzBuzzRepository;

    public FizzBuzzService(IFizzBuzzRepository fizzBuzzRepository)
    {
        _fizzBuzzRepository = fizzBuzzRepository;
    }

    public async Task<List<string>> GetFizzBuzzSeriesAsync(int randomNumber, int limit)
    {
        var series = new List<string>();
        for (int i = randomNumber; i <= limit; i++)
        {
             if (i % 3 == 0 && i % 5 == 0)
            {
                series.Add("fizzbuzz");
            }
            else if (i % 3 == 0)
            {
                series.Add("fizz");
            }
            else if (i % 5 == 0)
            {
                series.Add("buzz");
            }
            else
            {
                series.Add(i.ToString());
            }
        }

        // Write the series to a file with a datetime signature
        await _fizzBuzzRepository.WriteSeriesToFileAsync(series);

        return series;
    }
}



