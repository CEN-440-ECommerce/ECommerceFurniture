namespace Furniture.SignalR
{
    public static void AddSignalRServices(this IServiceCollection services)
    {
        services.AddTransient<IProductHubService, ProductHubService>();
        services.AddSignalR();
    }
}
