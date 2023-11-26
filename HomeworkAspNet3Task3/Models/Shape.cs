using Newtonsoft.Json;
using System.Xml.Serialization;

namespace HomeworkAspNet3Task3.Models
{
	[Serializable]
	[XmlRoot("Shape")]
	public class Shape
	{
		[JsonProperty("Id")]
		public int Id { get; set; }
		[JsonProperty("Name")]
		public string? Name { get; set; }
		[JsonProperty("Measure")]
		public string? Measure { get; set; }
		[JsonProperty("Color")]
		public string? Color { get; set; }

		public Shape() { }
	}
}
