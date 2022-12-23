

namespace WebApiFizzBuzz.Domain;





public interface IFizzBuzzRepository
{
    Task WriteSeriesToFileAsync(List<string> series);
}

public class FizzBuzzRepository : IFizzBuzzRepository
{




    private readonly ILogger _logger;

    public FizzBuzzRepository(ILogger<FizzBuzzRepository> logger)
    {
        _logger = logger;
    }

    public async Task WriteSeriesToFileAsync(List<string> series)
    {
        try
        {
            // Write the series to a file with a datetime signature
            var fileName = "fizzbuzz.txt";
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "FizzBuzzFiles");
           if (!Directory.Exists(directoryPath))
           {
            // Create the directory if it does not exist
            Directory.CreateDirectory(directoryPath);
           }





            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "FizzBuzzFiles", fileName);
             using (StreamWriter streamWriter = new StreamWriter(filePath, true))
        {
                     string seriesString = string.Join(",", series);
                     await streamWriter.WriteLineAsync($"{DateTime.Now}: {seriesString}");
        }
            
        }
        catch (Exception ex)
        {
            // Log the error using NLog
            _logger.LogError(ex, "An error occurred while writing the Fizz Buzz series to a file.");
        }
    }
}








