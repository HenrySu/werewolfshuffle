using System.Collections.Generic;
using Newtonsoft.Json;

namespace shuffle.models
{
    public class GameSetting
    {
        [JsonProperty("Attendees")] public List<Attendee> Attendees { get; set; }
        [JsonProperty("Rule")] public GameRule Rule { get; set; }
    }
}