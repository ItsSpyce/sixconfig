using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SixConfig.Models
{
  [JsonObject(MemberSerialization.OptOut)]
  public class Profile
  {
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("id")]
    public string Id { get; }

    public Profile(string id)
    {
      Id = id;
    }
  }
}
