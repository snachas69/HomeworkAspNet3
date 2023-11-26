using Autofac.Extensions.DependencyInjection;
using HomeworkAspNet3;

public class Program
{
	public static void Main(string[] args) =>
		CreateHostBuilder(args).Build().Run();

	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.UseServiceProviderFactory(new AutofacServiceProviderFactory())
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup<Startup>();
			});
}
