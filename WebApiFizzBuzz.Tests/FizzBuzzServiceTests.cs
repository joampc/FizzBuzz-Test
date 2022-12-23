
using System.Threading.Tasks;
using Xunit;
using WebApiFizzBuzz.Application;
using WebApiFizzBuzz.Domain;
using Moq;
using System.Collections.Generic;

namespace WebApiFizzBuzz.Tests
{
    public class FizzBuzzServiceTests
    {
       [Fact]
public async Task GetFizzBuzzSeriesAsync_ReturnsCorrectSeries()
{
    // Arrange
    var fizzBuzzRepositoryMock = new Mock<IFizzBuzzRepository>();
    var fizzBuzzService = new FizzBuzzService(fizzBuzzRepositoryMock.Object);
    var randomNumber = 1;
    var limit = 10;

    // Act
    var series = await fizzBuzzService.GetFizzBuzzSeriesAsync(randomNumber, limit);

    // Assert
    Assert.Equal(new List<string>
    {
        "1", "2", "fizz", "4", "buzz", "fizz", "7", "8", "fizz", "buzz"
    }, series);
}

    }
}