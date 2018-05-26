namespace FerramentaAuxilioImplantacao.App
{
	using System.Xml.Serialization;
	using System.Collections.Generic;

	[XmlRoot(ElementName = "add")]
	public class Item
	{
		[XmlAttribute(AttributeName = "key")]
		public string Key { get; set; }
		[XmlAttribute(AttributeName = "value")]
		public string Value { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "connectionString")]
		public string ConnectionString { get; set; }
	}

	[XmlRoot(ElementName = "appSettings")]
	public class AppSettings
	{
		[XmlElement(ElementName = "add")]
		public List<Item> Item { get; set; }
	}

	[XmlRoot(ElementName = "connectionStrings")]
	public class ConnectionStrings
	{
		[XmlElement(ElementName = "add")]
		public Item Item { get; set; }
	}

	[XmlRoot(ElementName = "configuration")]
	public class ConfigurationModel
	{
		[XmlElement(ElementName = "appSettings")]
		public AppSettings AppSettings { get; set; }
		[XmlElement(ElementName = "connectionStrings")]
		public ConnectionStrings ConnectionStrings { get; set; }
	}
}
