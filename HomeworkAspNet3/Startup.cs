﻿using Autofac;
using HomeworkAspNet3.Models;

namespace HomeworkAspNet3
{
	public class Startup
	{
		public IConfiguration? Configuration { get; }

		public Startup(IConfiguration? configuration) =>
			Configuration = configuration;

		public void ConfigureServices(IServiceCollection? services) =>
			services?.AddControllersWithViews();

		public void ConfigureContainer(ContainerBuilder builder) =>
			builder.RegisterType<Drink>().AsSelf();

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}

}
