using System;
using System.Threading.Tasks;
using ModernHttpClient;
using System.Net.Http;
using Newtonsoft.Json;
using Acr.UserDialogs;

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
				HttpClient Request = new HttpClient(new Xamarin.Android.Net.AndroidClientHandler());//new HttpClient(new NativeMessageHandler());
				var Response = await Request.GetAsync(URL);
				
				var ResultJson = await Response.Content.ReadAsStringAsync();

				return JsonConvert.DeserializeObject<T>(ResultJson);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return default(T);
			}

		}
	}


}
