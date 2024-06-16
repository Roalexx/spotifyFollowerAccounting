using Newtonsoft.Json;

public class Profile
{
    [JsonProperty("uri")]
    public string Uri { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("image_url")]
    public string ImageUrl { get; set; }

    [JsonProperty("followers_count")]
    public int FollowersCount { get; set; }

    [JsonProperty("is_followed")]
    public bool IsFollowed { get; set; }

    [JsonProperty("is_following")]
    public bool IsFollowing { get; set; }

    [JsonProperty("color")]
    public int Color { get; set; }
}

public class ExternalUrls
{
    [JsonProperty("spotify")]
    public string Spotify { get; set; }
}

public class Image
{
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }
}

public class Followers
{
    [JsonProperty("href")]
    public object Href { get; set; }

    [JsonProperty("total")]
    public int Total { get; set; }
}

public class ExplicitContent
{
    [JsonProperty("filter_enabled")]
    public bool FilterEnabled { get; set; }

    [JsonProperty("filter_locked")]
    public bool FilterLocked { get; set; }
}

public class User
{
    [JsonProperty("display_name")]
    public string DisplayName { get; set; }

    [JsonProperty("external_urls")]
    public ExternalUrls ExternalUrls { get; set; }

    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("images")]
    public List<Image> Images { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("uri")]
    public string Uri { get; set; }

    [JsonProperty("followers")]
    public Followers Followers { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("product")]
    public string Product { get; set; }

    [JsonProperty("explicit_content")]
    public ExplicitContent ExplicitContent { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }
}

public class Root
{
    [JsonProperty("profiles")]
    public List<Profile> Profiles { get; set; }
}