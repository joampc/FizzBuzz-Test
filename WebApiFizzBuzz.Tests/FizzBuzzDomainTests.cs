using System;
using System.IO;
using System.Threading.Tasks;
using WebApiFizzBuzz.Domain;
using Xunit;
using Moq;
using System.Collections.Generic;
 using Microsoft.Extensions.Logging;


namespace WebApiFizzBuzz.Tests
{
    public class FizzBuzzRepositoryTests
    {
        //private readonly ILogger<FizzBuzzRepository> _logger;

        [Fact]
        public async Task WriteSeriesToFileAsync_WritesSeriesToFile()
        {
            // Arrange
            var series = new List<string>() { "1", "2", "Fizz", "4", "Buzz" };
            var fileName = "fizzbuzz.txt";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "FizzBuzzFiles", fileName);

            // Ensure that the file doesn't exist
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // var logger = new FakeLogger();
            // var repository = new FizzBuzzRepository(logger);
             var logger = new FakeLogger<FizzBuzzRepository>();
           var repository = new FizzBuzzRepository(logger);

            // Create the repository
          //  var repository = new FizzBuzzRepository( _logger);

            // Act
            await repository.WriteSeriesToFileAsync(series);

            // Assert
            Assert.True(File.Exists(filePath));
        }
    }

// public class FakeLogger : ILogger
//     {
//     public bool LogErrorInvoked { get; set; }

//     public IDisposable BeginScope<TState>(TState state)
//     {
        
//         return new DummyDisposable();
//     }

//     public bool IsEnabled(LogLevel logLevel)
//     {
       
//         return true;
//     }

//     public void LogError(Exception exception, string message)
//     {
//         LogErrorInvoked = true;
//     }
// public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
//     {
//         LogErrorInvoked = true;
//     }
  
// }

      public class DummyDisposable : IDisposable
{
    public void Dispose()
    {
        // No action is necessary
    }
 }

public class FakeLogger<T> : ILogger<T>
{
    public bool LogErrorInvoked { get; set; }

    public IDisposable BeginScope<TState>(TState state)
    {
        return new DummyDisposable();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void LogError(Exception exception, string message)
    {
        LogErrorInvoked = true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        LogErrorInvoked = true;
    }
}

}
