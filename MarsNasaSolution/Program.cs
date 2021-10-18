using MarsNasaSolution.Repository.Invoker;
using MarsNasaSolution.Repository.Provider;
using MarsNasaSolution.Service;
using MarsNasaSolution.Service.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsNasaSolution
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var maxPoints = Console.ReadLine().Split(' ');
            var currentLocation = Console.ReadLine().Split(' ');
            var movement = Console.ReadLine();
            var currentLocation1 = Console.ReadLine().Split(' ');
            var movement1 = Console.ReadLine();

            var services = new ServiceCollection();
            services.AddSingleton<IMarsNasaSolutionService, MarsNasaSolutionService>();
            services.AddSingleton<Invoker, ExecuteAction>();
            var _serviceProvider = services.BuildServiceProvider(true);
            var _marsRoverProblemSolutionService = _serviceProvider.GetService<IMarsNasaSolutionService>();
            var _invoker = _serviceProvider.GetService<Invoker>();

            var coordinates = _marsRoverProblemSolutionService.MoveRover(maxPoints, currentLocation, movement, _invoker);
            var coordinates2 = _marsRoverProblemSolutionService.MoveRover(maxPoints, currentLocation1, movement1, _invoker);

            if (coordinates != null)
            {
                Console.WriteLine(coordinates.X + " " + coordinates.Y + " " + coordinates.Dir);

            }
            else
                Console.WriteLine("Bad Request");

            if (coordinates2 != null)
            {
                Console.WriteLine(coordinates2.X + " " + coordinates2.Y + " " + coordinates2.Dir);

            }
            else
                Console.WriteLine("Bad Request");

            DisposeServices(_serviceProvider);
        }

        /// <summary>
        /// dispose services
        /// </summary>
        /// <param name="_serviceProvider"></param>
        private static void DisposeServices(ServiceProvider _serviceProvider)
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}
