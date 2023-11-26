using HomeworkAspNet3Task2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Xml.Serialization;

namespace HomeworkAspNet3Task2.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public List<Unit> Units { get; set; }

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;

			Units = GetUnits();
		}

		public IActionResult Index()
		{
			return View(Units);
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

		private List<Unit> GetUnits() =>
			new List<Unit>()
			{
				new Archer() { Id = 1, Name = "Legolas", Level = 30, Stats = "Attack: 85\nDefense: 60 \nSpeed: 95 \nUnique Archer Skill: Eagle Eye (increases accuracy by 20%)" },
				new Warrior() { Id = 2, Name = "Thor", Level = 35, Stats = "Attack: 90 \nDefense: 80 \nSpeed: 70 \nUnique Warrior Skill: Mjolnir Strike (deals lightning damage on critical hits)" },
				new Spearman() { Id = 3, Name = "Achilles", Level = 32, Stats = "Attack: 88 \nDefense: 75 \nSpeed: 82 \nUnique Spearman Skill: Invincible Phalanx (increases defense against ranged attacks)" },
				new Archer() { Id = 4, Name = "Sylvanas", Level = 28, Stats = "Attack: 80 \nDefense: 55 \nSpeed: 92 \nUnique Archer Skill: Shadow Shot (deals bonus damage from stealth)" },
				new Warrior() { Id = 5, Name = "Xena", Level = 33, Stats = "Attack: 92 \nDefense: 78 \nSpeed: 68 \nUnique Warrior Skill: Chakram Throw (long-range spinning blade attack)" },
				new Spearman() { Id = 6, Name = "Leonidas", Level = 34, Stats = "Attack: 89 \nDefense: 82 \nSpeed: 75 \nUnique Spearman Skill: Spartan Phalanx (increases attack when surrounded by enemies)" },
				new Archer() { Id = 7, Name = "Hawkeye", Level = 29, Stats = "Attack: 82 \nDefense: 58 \nSpeed: 90 \nUnique Archer Skill: Trick Shot (bypasses enemy defenses)" },
				new Warrior() { Id = 8, Name = "Diane", Level = 36, Stats = "Attack: 95 \nDefense: 85 \nSpeed: 72 \nUnique Warrior Skill: Lasso of Truth (disarms and stuns enemies)" },
				new Spearman() { Id = 9, Name = "Joan d'Arc", Level = 31, Stats = "Attack: 86 \nDefense: 73 \nSpeed: 80 \nUnique Spearman Skill: Divine Intervention (heals nearby allies in battle)" },
				new Archer() { Id = 10, Name = "Artemis", Level = 27, Stats = "Attack: 78 \nDefense: 52 \nSpeed: 88 \nUnique Archer Skill: Moonlit Volley (fires a rapid barrage of arrows)" }
			};

		[HttpPost]
		public IActionResult Upload(int fileType)
		{
			switch (fileType)
			{
				case 1: // XML
					XmlSerializer serializer = new XmlSerializer(typeof(List<Unit>));
					using (FileStream fileStream = new FileStream("UnitsXML.txt", FileMode.Create))
					{
						serializer.Serialize(fileStream, Units);
					}
					break;
				case 2: // JSON
					string jsonData = JsonSerializer.Serialize(Units, new JsonSerializerOptions { WriteIndented = true });
					System.IO.File.WriteAllText("UnitsJSON.txt", jsonData);
					break;
				default:
					return BadRequest("Unsupported format");
			}

			return Ok("File saved successfully");
		}
	}
}