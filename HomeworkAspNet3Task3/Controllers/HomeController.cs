using HomeworkAspNet3Task3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Xml.Serialization;

namespace HomeworkAspNet3Task3.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public List<Shape> Shapes { get; set; }

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;

			Shapes = GetShapes();
		}

		public IActionResult Index()
		{
			return View(Shapes);
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

		private List<Shape> GetShapes() =>
			new List<Shape>()
			{
				new Shape() { Id = 1, Name = "Circle", Measure = "Radius = 7", Color = "Red" },
				new Shape() { Id = 2, Name = "Triangle", Measure = "Side Length = 3", Color = "Blue" },
				new Shape() { Id = 3, Name = "Square", Measure = "Side Length = 5", Color = "Green" },
				new Shape() { Id = 4, Name = "Rectangle", Measure = "Length = 6, Width = 4", Color = "Yellow" },
				new Shape() { Id = 5, Name = "Pentagon", Measure = "Side Length = 4", Color = "Purple" },
				new Shape() { Id = 6, Name = "Hexagon", Measure = "Side Length = 8", Color = "Orange" },
				new Shape() { Id = 7, Name = "Octagon", Measure = "Side Length = 7", Color = "Pink" },
				new Shape() { Id = 8, Name = "Ellipse", Measure = "Major Axis = 10, Minor Axis = 6", Color = "Brown" },
				new Shape() { Id = 9, Name = "Rhombus", Measure = "Diagonal Length = 8, Side Length = 6", Color = "Cyan" },
				new Shape() { Id = 10, Name = "Trapezoid", Measure = "Base 1 = 8, Base 2 = 6, Height = 4", Color = "Gray" }
			};

		[HttpPost]
		public IActionResult Upload(int fileType)
		{
			switch (fileType)
			{
				case 1: // XML
					XmlSerializer serializer = new XmlSerializer(typeof(List<Shape>));
					using (FileStream fileStream = new FileStream("ShapesXML.txt", FileMode.Create))
					{
						serializer.Serialize(fileStream, Shapes);
					}
					break;
				case 2: // JSON
					string jsonData = JsonSerializer.Serialize(Shapes, new JsonSerializerOptions { WriteIndented = true });
					System.IO.File.WriteAllText("ShapesJSON.txt", jsonData);
					break;
				default:
					return BadRequest("Unsupported format");
			}

			return Ok("File saved successfully");
		}
	}
}