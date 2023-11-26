using HomeworkAspNet3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Xml.Serialization;

namespace HomeworkAspNet3.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		List<Drink> Drinks { get; set; }

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;

			Drinks = GetDrink();
		}

		public IActionResult Index()
		{
			return View(Drinks);
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

		private List<Drink> GetDrink() => 
			new List<Drink>()
			{
				new Drink() { Id = 1, Name = "Mai Tai", StandardSize = 177, ContainsAlcohol = true, Composition = "White rum\nDark rum\nLime juice\nOrange liqueur (such as triple sec)\nOrgeat syrup (almond-flavored syrup)" },
				new Drink() { Id = 2, Name = "Pisco Sour", StandardSize = 118, ContainsAlcohol = true, Composition = "Pisco (a type of brandy)\nLime juice\nSimple syrup\nEgg white" },
				new Drink() { Id = 3, Name = "Singapore Sling", StandardSize = 237, ContainsAlcohol = true, Composition = "Gin\nCherry liqueur\nHerbal liqueur (such as Bénédictine)\nPineapple juice\nLime juice\nGrenadine" },
				new Drink() { Id = 4, Name = "Caipirinha", StandardSize = 237, ContainsAlcohol = true, Composition = "Cachaça (sugar cane spirit)\nLime\nSugar" },
				new Drink() { Id = 5, Name = "Sazerac", StandardSize = 89, ContainsAlcohol = true, Composition = "Rye whiskey\nAbsinthe (or absinthe substitute)\nPeychaud's Bitters\nSugar cube (optional)" },
				new Drink() { Id = 6, Name = "Mojito", StandardSize = 237, ContainsAlcohol = true, Composition = "White rum\nLime juice\nSimple syrup\nMint leaves\nSoda water" },
				new Drink() { Id = 7, Name = "Dark'n'Stormy", StandardSize = 237, ContainsAlcohol = true, Composition = "Dark rum\nGinger beer" },
				new Drink() { Id = 8, Name = "Aperol Spritz", StandardSize = 177, ContainsAlcohol = true, Composition = "Aperol (bitter orange liqueur)\nProsecco (Italian sparkling wine)\nSoda water\nOrange slice (for garnish)" },
				new Drink() { Id = 9, Name = "Paloma", StandardSize = 237, ContainsAlcohol = true, Composition = "Tequila\nGrapefruit soda\nLime juice\nSalt (for rimming the glass)" },
				new Drink() { Id = 10, Name = "Tom Collins", StandardSize = 237, ContainsAlcohol = true, Composition = "Gin\nLemon juice\nSimple syrup\nSoda water" }
			};

		[HttpPost]
		public IActionResult Upload(int fileType)
		{	
			switch (fileType)
			{
				case 1: // XML
					XmlSerializer serializer = new XmlSerializer(typeof(List<Drink>));
					using (FileStream fileStream = new FileStream("DrinksXML.txt", FileMode.Create))
					{
						serializer.Serialize(fileStream, Drinks);
					}
					break;
				case 2: // JSON
					string jsonData = JsonSerializer.Serialize(Drinks, new JsonSerializerOptions { WriteIndented = true });
					System.IO.File.WriteAllText("DrinksJSON.txt", jsonData);
					break;
				default:
					return BadRequest("Unsupported format");
			}

			return Ok("File saved successfully");
		}
	}
}