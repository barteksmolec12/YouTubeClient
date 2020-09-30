using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoutubeClient.Models
{
	public class YtResponse
	{
		public Item[] items { get; set; }
		public class Item
		{
			public string id { get; set; }
			public Snippet snippet { get; set; }
		}
		public class Snippet
		{
			public string title { get; set; }
			public string description { get; set; }
		}
	}
}
