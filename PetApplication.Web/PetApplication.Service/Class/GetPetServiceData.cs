namespace PetWithOwnerApplication.Service.Class
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Runtime.Caching;
    using Entity;
    using Newtonsoft.Json;
    using Utility;

    public class GetPetServiceData : IGetPetServiceData
    {
        private readonly MemoryCache _cache = MemoryCache.Default;
        private string _petOwnerResult;

        public IEnumerable<PetOwnerModel> GetPetDataFromService()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    Log.Logging(httpClient.DefaultRequestHeaders.ToString());

                    // If MemoryCaching Needed
                    bool isMemoryCacheEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings[Constant.IsMemoryCacheEnabled]);

                    // Check in Cache
                    if (this._cache.Get(Constant.CacheKey) == null)
                    {
                       this._petOwnerResult = httpClient.GetStringAsync(new Uri(ConfigurationManager.AppSettings[Constant.ApiUrl])).Result;
                        if (isMemoryCacheEnabled)
                        {
                            this._cache.Add(Constant.CacheKey, this._petOwnerResult,
                                new CacheItemPolicy
                                {
                                    AbsoluteExpiration = DateTime.Now.AddSeconds(60)
                                });
                        }
                    }
                    else
                    {
                       this._petOwnerResult = Convert.ToString(this._cache.Get(Constant.CacheKey));
                    }

                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };

                    return JsonConvert.DeserializeObject<List<PetOwnerModel>>(this._petOwnerResult, settings);
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex);
                throw;
            }
        }
    }
}
