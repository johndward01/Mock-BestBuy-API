namespace CommandLine_API
{
    using CommandLine_API.Commands;
    using CommandLine_API.Mappers;
    using CommandLine_API.Repositories;
    using CommandLine_API.Services;
    using CommandLine_API.ViewModels;
    using Boxed.Mapping;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods add project services.
    /// </summary>
    /// <remarks>
    /// AddSingleton - Only one instance is ever created and returned.
    /// AddScoped - A new instance is created and returned for each request/response cycle.
    /// AddTransient - A new instance is created and returned each time.
    /// </remarks>
    public static class ProjectServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectCommands(this IServiceCollection services) =>
            services
                .AddSingleton<DeleteCarCommand>()
                .AddSingleton<GetCarCommand>()
                .AddSingleton<GetCarPageCommand>()
                .AddSingleton<PatchCarCommand>()
                .AddSingleton<PostCarCommand>()
                .AddSingleton<PutCarCommand>();

        public static IServiceCollection AddProjectMappers(this IServiceCollection services) =>
            services
                .AddSingleton<IMapper<Models.Car, Car>, CarToCarMapper>()
                .AddSingleton<IMapper<Models.Car, SaveCar>, CarToSaveCarMapper>()
                .AddSingleton<IMapper<SaveCar, Models.Car>, CarToSaveCarMapper>();

        public static IServiceCollection AddProjectRepositories(this IServiceCollection services) =>
            services
                .AddSingleton<ICarRepository, CarRepository>();

        public static IServiceCollection AddProjectServices(this IServiceCollection services) =>
            services
                .AddSingleton<IClockService, ClockService>();
    }
}
