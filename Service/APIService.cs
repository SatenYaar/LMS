
using LMS.Models.EmployeeModel;
using LMS.Models.ViewModel;
using LMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace LMS.Service
{
	public class APIService:IAPTService
	{
		public async Task<APIResponse> CalAPI(string sUrl, string sTokenUrl)
		{
			APIResponse getapiresponse = new APIResponse();
			try
			{
				HttpClientHandler clientHandler = new HttpClientHandler();
				clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
				using (HttpClient client = new HttpClient(clientHandler))
				{
					HttpResponseMessage message = await client.GetAsync(sTokenUrl);
					if (message.StatusCode == System.Net.HttpStatusCode.OK)
					{
						string sToken = await message.Content.ReadAsStringAsync();
						client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sToken);
						HttpResponseMessage response = await client.GetAsync(sUrl);
						if (response.StatusCode == System.Net.HttpStatusCode.OK)
						{
							string apiResponse = await response.Content.ReadAsStringAsync();
							getapiresponse = JsonConvert.DeserializeObject<APIResponse>(apiResponse);
						}
					}
				}
			}
			catch (Exception ex)
			{
				getapiresponse.Result = ex.Message.ToString();
				getapiresponse.StatusCode = System.Net.HttpStatusCode.NotFound;
			}
			return getapiresponse;
		}

        public async Task<APIResponse> PostAPI(string sUrl, string sTokenUrl,EmployeeModel data)
        {
            APIResponse Postapiresponse = new APIResponse();
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    HttpResponseMessage message = await client.GetAsync(sTokenUrl);
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string sToken = await message.Content.ReadAsStringAsync();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sToken);
                        HttpResponseMessage response = await client.PostAsJsonAsync(sUrl, data);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            Postapiresponse = JsonConvert.DeserializeObject<APIResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Postapiresponse.Result = ex.Message.ToString();
                Postapiresponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return Postapiresponse;
        }

        public async Task<APIResponse> PutAPI(string sUrl, string sTokenUrl, EmployeeModel data)
        {
            APIResponse Postapiresponse = new APIResponse();
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    HttpResponseMessage message = await client.GetAsync(sTokenUrl);
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string sToken = await message.Content.ReadAsStringAsync();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sToken);
                        HttpResponseMessage response = await client.PutAsJsonAsync(sUrl, data);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            Postapiresponse = JsonConvert.DeserializeObject<APIResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Postapiresponse.Result = ex.Message.ToString();
                Postapiresponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return Postapiresponse;
        }
        public async Task<APIResponse> SignUpPostAPI(string sUrl, string sTokenUrl, SignUpModel signUp)
        {
            APIResponse Postapiresponse = new APIResponse();
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    HttpResponseMessage message = await client.GetAsync(sTokenUrl);
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string sToken = await message.Content.ReadAsStringAsync();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sToken);
                        HttpResponseMessage response = await client.PostAsJsonAsync(sUrl, signUp);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            Postapiresponse = JsonConvert.DeserializeObject<APIResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Postapiresponse.Result = ex.Message.ToString();
                Postapiresponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return Postapiresponse;
        }

        public async Task<APIResponse> LoginPostAPI(string sUrl, string sTokenUrl, LoginModel login)
        {
            APIResponse Postapiresponse = new APIResponse();
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    HttpResponseMessage message = await client.GetAsync(sTokenUrl);
                    if (message.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string sToken = await message.Content.ReadAsStringAsync();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sToken);
                        HttpResponseMessage response = await client.PostAsJsonAsync(sUrl, login);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            Postapiresponse = JsonConvert.DeserializeObject<APIResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Postapiresponse.Result = ex.Message.ToString();
                Postapiresponse.StatusCode = System.Net.HttpStatusCode.NotFound;
            }
            return Postapiresponse;
        }

    }
}
