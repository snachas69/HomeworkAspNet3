using HomeworkAspNet3Task4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Xml.Serialization;

namespace HomeworkAspNet3Task4.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public List<Appliance> Appliances { get; set; }

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;

			Appliances = GetAppliance();
		}

		public IActionResult Index()
		{
			return View(Appliances);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		private List<Appliance> GetAppliance() =>
			new List<Appliance>()
			{
				new Appliance() { Id = 1, Name = "Refrigerator", Price = 899.99m, Description = "A spacious refrigerator with adjustable shelves and a freezer compartment" },
				new Appliance() { Id = 2, Name = "Washing Machine", Price = 649.95m, Description = "High-capacity front-loading washing machine with multiple wash programs" },
				new Appliance() { Id = 3, Name = "Microwave Oven", Price = 79.99m, Description = "Compact microwave oven with quick-cooking features and easy-to-use controls" },
				new Appliance() { Id = 4, Name = "Dishwasher", Price = 549.00m, Description = "Energy-efficient dishwasher with multiple wash cycles and adjustable racks" },
				new Appliance() { Id = 5, Name = "Coffee Maker", Price = 129.50m, Description = "Programmable coffee maker with a built-in grinder for freshly ground coffee" },
				new Appliance() { Id = 6, Name = "Smart TV", Price = 799.99m, Description = " 55-inch smart TV with 4K resolution, streaming apps, and voice control" },
				new Appliance() { Id = 7, Name = "Air Purifier", Price = 149.95m, Description = "HEPA air purifier with multiple filtration stages for cleaner indoor air" },
				new Appliance() { Id = 8, Name = "Toaster Oven", Price = 89.99m, Description = "Versatile toaster oven with convection baking and broiling functions" },
				new Appliance() { Id = 9, Name = "Robot Vacuum Cleaner", Price = 299.00m, Description = "Intelligent robot vacuum with mapping technology for efficient cleaning" },
				new Appliance() { Id = 10, Name = "Blender", Price = 129.99m, Description = "High-performance blender with multiple speed settings for smoothies and more" }
			};

		[HttpPost]
		public IActionResult Upload(int fileType)
		{
			switch (fileType)
			{
				case 1: // XML
					XmlSerializer serializer = new XmlSerializer(typeof(List<Appliance>));
					using (FileStream fileStream = new FileStream("AppliancesXML.txt", FileMode.Create))
					{
						serializer.Serialize(fileStream, Appliances);
					}
					break;
				case 2: // JSON
					string jsonData = JsonSerializer.Serialize(Appliances, new JsonSerializerOptions { WriteIndented = true });
					System.IO.File.WriteAllText("AppliancesJSON.txt", jsonData);
					break;
				default:
					return BadRequest("Unsupported format");
			}

			return Ok("File saved successfully");
		}
	}
}