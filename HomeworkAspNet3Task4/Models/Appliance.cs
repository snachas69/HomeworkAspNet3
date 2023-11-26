using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace HomeworkAspNet3Task4.Models
{
	[Serializable]
	[XmlRoot("Appliance")]
	public class Appliance
	{
		[JsonPropertyName("Id")]
		public int Id { get; set; }
		[JsonPropertyName("Name")]
		public string? Name { get; set; }
		[JsonPropertyName("Price")]
		public decimal Price { get; set; }
		[JsonPropertyName("Description")]
		public string? Description { get; set; }

		public Appliance() { }
	}
}
