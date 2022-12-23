using System.Threading.Tasks;
using Moq;
using WebApiFizzBuzz.Domain;
using System.Collections.Generic;


namespace WebApiFizzBuzz.Tests
{
    public class FakeFizzBuzzRepository : Mock<IFizzBuzzRepository>
    {
        public bool WriteSeriesToFileAsyncInvoked { get; private set; }

        public FakeFizzBuzzRepository()
        {
            Setup(x => x.WriteSeriesToFileAsync(It.IsAny<List<string>>()))
                .Callback(() => WriteSeriesToFileAsyncInvoked = true)
                .Returns(Task.CompletedTask);
        }
    }
}