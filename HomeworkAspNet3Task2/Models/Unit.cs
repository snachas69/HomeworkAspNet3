using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace HomeworkAspNet3Task2.Models
{
	[Serializable]
	[XmlInclude(typeof(Warrior))]
	[XmlInclude(typeof(Archer))]
	[XmlInclude(typeof(Spearman))]
	public abstract class Unit
	{
		[JsonPropertyName("Id")]
		public int Id { get; set; }
		[JsonPropertyName("Name")]
		public string? Name { get; set; }
		[JsonPropertyName("Stats")]
		public string? Stats { get; set; }
		[JsonPropertyName("Level")]
		public int Level { get; set; }
	}
}
