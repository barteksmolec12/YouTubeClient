using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoutubeClient.Models;

namespace YoutubeClient.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			
		}
		
		public async Task<IActionResult> Videos(string search)
			
		{
			//var url= "https://www.googleapis.com/youtube/v3/videos?part=snippet&chart=mostPopular&key=AIzaSyA9sQE7z355rTXtc6q65BPmipW5LcFEovA";
			var url= "https://www.googleapis.com/youtube/v3/search?part=snippet&q=trial%20bike&key=AIzaSyA9sQE7z355rTXtc6q65BPmipW5LcFEovA";
			var client = new HttpClient();
			var response =await client.GetAsync(url);
			IEnumerable<Video> ytVideos = Enumerable.Empty<Video>();
			if (response.IsSuccessStatusCode)
			{
				var ytStringResponse = await response.Content.ReadAsStringAsync();
				var ytRepsonse = Newtonsoft.Json.JsonConvert.DeserializeObject<YtResponse>(ytStringResponse);





				ytVideos = ytRepsonse.items.Select(n => new Video
				{
					LinkSrc= "https://www.youtube.com/embed/"+n.id.videoId,
					Title = n.snippet.title,
					

				}
				
				); ;

			}
			return View(ytVideos);
		}
		public IActionResult Index()
		{
			return View();
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
	}
}
