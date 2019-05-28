
namespace PetWithOwnerApplication.Entity
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    public class PetOwnerModel 
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("pets")]
        public List<PetModel> Pets { get; set; }
    }
}
