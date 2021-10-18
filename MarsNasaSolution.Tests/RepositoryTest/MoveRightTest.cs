using MarsNasaSolution.Data.Constants;
using MarsNasaSolution.Repository.Command;
using MarsNasaSolution.Repository.Provider;
using MarsNasaSolution.Tests.MockObjects;
using Xunit;

namespace MarsNasaSolution.Tests.RepositoryTest
{
    public class MoveRightTest
    {
        /// <summary>
        /// command reference
        /// </summary>
        private readonly Command _command;

        /// <summary>
        /// constructor
        /// </summary>
        public MoveRightTest()
        {
            _command = new MoveRight();
        }

        /// <summary>
        /// test for Execute method
        /// </summary>
        /// <param name="directions"></param>
        [Theory]
        [InlineData(Directions.N)]
        [InlineData(Directions.E)]
        [InlineData(Directions.S)]
        [InlineData(Directions.W)]
        public void Execute_Test(Directions directions)
        {
            //Arrange
            var coordinates = MockData.Coordinates();
            switch (directions)
            {
                case Directions.N:
                    coordinates.Dir = Directions.N;
                    break;

                case Directions.E:
                    coordinates.Dir = Directions.E;
                    break;

                case Directions.S:
                    coordinates.Dir = Directions.S;
                    break;

                case Directions.W:
                    coordinates.Dir = Directions.W;
                    break;
            }

            //Act
            var result = _command.Execute(coordinates);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(coordinates, result);
        }
    }
}
