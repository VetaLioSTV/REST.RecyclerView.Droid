using System;
using System.Threading.Tasks;
using ModernHttpClient;
using System.Net.Http;
using Newtonsoft.Json;
using Acr.UserDialogs;
using System.Net;
using System.IO;

namespace Rest.RecyclerView.Droid
{
	public class Client
	{
		const string URL = "https://jsonplaceholder.typicode.com/users";

		public async static Task<T> GetRequestData<T>()
		{
			try
			{
				//android 5.0 +
				using (HttpClient Request = new HttpClient(new Xamarin.Android.Net.AndroidClientHandler()))//new HttpClient(new NativeMessageHandler());
				{
					using (var Response = await Request.GetAsync(URL))
					{
						//ne pravilno tak delat :D
						UserDialogs.Instance.Progress().PercentComplete = 100;
						await Task.Delay(1000);
						UserDialogs.Instance.ShowSuccess("Worked");
						await Task.Delay(1000);
						//var ResultJson = await Response.Content.ReadAsStringAsync();

						return JsonConvert.DeserializeObject<T>(await Response.Content.ReadAsStringAsync());
					}
					
				}

			}
			catch (Exception ex)
			{
				UserDialogs.Instance.ShowError($"Error {ex.Message}");
				Console.WriteLine(ex.Message);
				return default(T);
			}

		}

		public async static Task<T> FetchData<T>()
		{
			HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);

			Request.Method = WebRequestMethods.Http.Get;
			Request.ContentType = "application/json";

			// Send the request to the server and wait for the response:
			using (WebResponse Response = await Request.GetResponseAsync())
			{
				// Get a stream representation of the HTTP web response:
				using (var Str = new StreamReader(Response.GetResponseStream()))
				{
					return JsonConvert.DeserializeObject<T>(await Str.ReadToEndAsync());
				}
			}

		}
	}
}

