using MarsNasaSolution.Data.Entities;

namespace MarsNasaSolution.Repository.Provider
{
    public interface Command
    {
        /// <summary>
        /// execute rover rotation/movement
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public Coordinates Execute(Coordinates coordinates);
    }
}
