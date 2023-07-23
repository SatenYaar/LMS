using Newtonsoft.Json;
using System.Net;

namespace LMS.Service
{
	public class APIResponse
	{
		[JsonProperty("result")]
		public dynamic Result { get; set; }

		[JsonProperty("statusCode")]
		public HttpStatusCode StatusCode { get; set; }
	}
}
