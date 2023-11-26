using Newtonsoft.Json;
using System.Xml.Serialization;

namespace HomeworkAspNet3.Models
{
	[Serializable]
	[XmlRoot("Drink")]
	public class Drink
	{
		[JsonProperty("Id")]
		public int Id { get; set; }
		[JsonProperty("Name")]
		public string? Name { get; set; }
		[JsonProperty("StandardSize")]
		public int StandardSize { get; set; }
		[JsonProperty("ContainsAlcohol")]
		public bool ContainsAlcohol { get; set; }
		[JsonProperty("Composition")]
		public string? Composition { get; set; }

		public Drink() { }
	}
}
