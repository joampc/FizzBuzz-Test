// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using WebApiFizzBuzz.Application;
// using WebApiFizzBuzz.DistributedServices;
// using Xunit;

// namespace WebApiFizzBuzz.Tests
// {
//     public class FizzBuzzControllerTests
//     {
//         [Fact]
//         public async Task GetFizzBuzzSeries_ReturnsOkResult()
//         {
//             // Arrange
//             var randomNumber = 3;
//             var limit = 5;
//             var series = new List<string> { "1", "2", "fizz", "4", "buzz" };
//             var fizzBuzzService = new FakeFizzBuzzService(series);
//             var logger = new FakeLogger();
//             var controller = new FizzBuzzController(fizzBuzzService, logger);

//             // Act
//             var result = await controller.GetFizzBuzzSeries(randomNumber, limit);

//             // Assert
//             Assert.IsType<OkObjectResult>(result);
//             Assert.Equal(series, ((OkObjectResult)result).Value);
//         }

//         [Fact]
//         public async Task GetFizzBuzzSeries_ReturnsInternalServerErrorResult()
//         {
//             // Arrange
//             var randomNumber = 3;
//             var limit = 5;
//             var fizzBuzzService = new FakeFizzBuzzService(exception: new Exception());
//             var logger = new FakeLogger();
//             var controller = new FizzBuzzController(fizzBuzzService, logger);

//             // Act
//             var result = await controller.GetFizzBuzzSeries(randomNumber, limit);

//             // Assert
//             Assert.IsType<StatusCodeResult>(result);
//             Assert.Equal(500, ((StatusCodeResult)result).StatusCode);
//             Assert.True(logger.LogInvoked);
//         }
//     }
// }

//  using System.Collections.Generic;
// using System.Threading.Tasks;
// using Xunit;
// using Microsoft.AspNetCore.Mvc;
// using Moq;
// using WebApiFizzBuzz.Application;
// using WebApiFizzBuzz.DistributedServices;
// using Microsoft.Extensions.Logging;

// namespace WebApiFizzBuzz.Tests
// {
//     public class FizzBuzzControllerTests
//     {
//         [Fact]
//         public async Task GetFizzBuzzSeries_ReturnsOkResult()
//         {
//             // Arrange
//             var fizzBuzzServiceMock = new Mock<IFizzBuzzService>();
//             var loggerMock = new Mock<ILogger<FizzBuzzController>>();
//             var fizzBuzzController = new FizzBuzzController(fizzBuzzServiceMock.Object, loggerMock.Object);
//             var randomNumber = 1;
//             var limit = 10;
//             fizzBuzzServiceMock
//                 .Setup(service => service.GetFizzBuzzSeriesAsync(randomNumber, limit))
//                 .ReturnsAsync(new List<string>
//                 {
//                     "1", "2", "fizz", "4", "buzz", "fizz", "7", "8", "fizz", "buzz"
//                 });

//             // Act
//             var result = await fizzBuzzController.GetFizzBuzzSeries(randomNumber, limit);

//             // Debug
//             var resultType = result.GetType();
//             var objectResultType = typeof(OkObjectResult);
//             var isAssignable = objectResultType.IsAssignableFrom(resultType);
            
//             //var objectResult = result as OkObjectResult;

//             var okResult = result as OkObjectResult;
//             var value = okResult.Value;

//             // Assert
//             Assert.IsType<OkObjectResult>(result);
//             Assert.IsAssignableFrom<OkObjectResult>(result);
//             Assert.NotNull(objectResult);
//         }
//     }
// }




using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiFizzBuzz.Application;
using Xunit;
using Moq;
using WebApiFizzBuzz.DistributedServices;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace WebApiFizzBuzz.Tests
{
    public class FizzBuzzControllerTests
    {
       [Fact]
        
// public async Task GetFizzBuzzSeries_ReturnsOkResult()
// {
//     // Arrange
//     var fizzBuzzService = new Mock<IFizzBuzzService>();
//     fizzBuzzService.Setup(x => x.GetFizzBuzzSeriesAsync(It.IsAny<int>(), It.IsAny<int>()))
//         .ReturnsAsync(new List<string> { "1", "2", "fizz", "4", "buzz" });
//     var controller = new FizzBuzzController(fizzBuzzService.Object, null);

//     // Act
//     var result = await controller.GetFizzBuzzSeries(1, 5);

//     // Assert
//     fizzBuzzService.Verify(x => x.GetFizzBuzzSeriesAsync(1, 5), Times.Once());
//     Assert.IsType<OkObjectResult>(result);

//     var okResult = result.Result as OkObjectResult;
//     Assert.IsType<List<string>>(okResult.Value);
//     var value = okResult.Value as List<string>;

//     Assert.Equal(5, value.Count);
// }

public async Task GetFizzBuzzSeries_ReturnsOkResult()
{
    // Arrange
    var fizzBuzzService = new Mock<IFizzBuzzService>();
    fizzBuzzService.Setup(x => x.GetFizzBuzzSeriesAsync(It.IsAny<int>(), It.IsAny<int>()))
        .ReturnsAsync(new List<string> { "1", "2", "fizz", "4", "buzz" });
    var controller = new FizzBuzzController(fizzBuzzService.Object, null);

    // Act
    var result = await controller.GetFizzBuzzSeries(1, 5);

    // Assert
    fizzBuzzService.Verify(x => x.GetFizzBuzzSeriesAsync(1, 5), Times.Once());
    Assert.IsType<OkObjectResult>(result);

    var value = result.Value;
    Assert.IsType<List<string>>(value);
    Assert.Equal(5, value.Count);
}



    }
}
