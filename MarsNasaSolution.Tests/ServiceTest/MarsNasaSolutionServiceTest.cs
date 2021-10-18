using FakeItEasy;
using MarsNasaSolution.Data.Entities;
using MarsNasaSolution.Repository.Provider;
using MarsNasaSolution.Service;
using MarsNasaSolution.Service.Provider;
using MarsNasaSolution.Tests.MockObjects;
using Xunit;

namespace MarsNasaSolution.Tests.ServiceTest
{
    public class MarsNasaSolutionServiceTest
    {
        /// <summary>
        /// invoker reference
        /// </summary>
        private readonly Invoker _invoker;

        /// <summary>
        /// IMarsNasaSolutionService reference
        /// </summary>
        private readonly IMarsNasaSolutionService _marsNasaSolutionService;

        /// <summary>
        /// constructor
        /// </summary>
        public MarsNasaSolutionServiceTest()
        {
            _invoker = A.Fake<Invoker>();
            _marsNasaSolutionService = new MarsNasaSolutionService();
        }

        /// <summary>
        /// test for MoveRover method
        /// </summary>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MoveRoverSync_Test(bool isCoordinateNull)
        {
            //Arrange
            var maxPoints = MockData.MaxPoints;
            var currentLocation = MockData.CurrentLocation;
            var movement = MockData.Movement;
            var coordinates = MockData.Coordinates();
            if (!isCoordinateNull)
                A.CallTo(() => _invoker.StartMoving(A<Command>._, A<Coordinates>._)).ReturnsLazily(() => coordinates);
            else
                A.CallTo(() => _invoker.StartMoving(A<Command>._, A<Coordinates>._)).ReturnsLazily(() => null);

            //Act
            var result = _marsNasaSolutionService.MoveRover(maxPoints, currentLocation, movement, _invoker);

            //Assert
            if (!isCoordinateNull)
            {
                Assert.NotNull(result);
                Assert.Equal(coordinates.X, result.X);
                Assert.Equal(coordinates.Y, result.Y);
                Assert.Equal(coordinates.Dir, result.Dir);
            }
            else
            {
                Assert.Null(result);
            }
        }
    }
}
