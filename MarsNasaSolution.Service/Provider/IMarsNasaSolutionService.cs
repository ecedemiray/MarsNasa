using MarsNasaSolution.Data.Entities;
using MarsNasaSolution.Repository.Provider;

namespace MarsNasaSolution.Service.Provider
{
    public interface IMarsNasaSolutionService
    {
        /// <summary>
        /// rover movement
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="currentLocation"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        Coordinates MoveRover(string[] maxPoints, string[] currentLocation, string movement, Invoker _invoker);
    }
}
