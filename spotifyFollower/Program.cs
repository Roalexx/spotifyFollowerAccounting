using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main()
    {
        await Console.Out.WriteLineAsync("Spotify follower accounting v0.1");

        await Console.Out.WriteLineAsync("Warning this app is on Early Access follow https://github.com/Roalexx for new versions");

        await Console.Out.WriteLineAsync("first go to your profile in website then press ctrl+shift+c then go to network tab and press followers then right click onfollowers?market=from_token press copy and copy as curl(bash) and paste this curl here");

        string curlCommand = ReadMultilineInput(); //we took curl

        string command = curlCommand.ToString();

        string authorization = authorizationFinder(command); //we took auth we need auth for all requests 

        JObject myInfo = await HttpRequest_me(authorization); //we need user id so we took our data

        string myId = (string)myInfo["id"]; // and weeding our id for next request

        JObject followers = await HttpRequest_followers(authorization,myId);

        JObject following = await HttpRequest_following(authorization,myId);

        await Console.Out.WriteLineAsync(following.ToString());

    }

    static string ReadMultilineInput()
    {
        string input;
        string result = string.Empty;

        while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
        {
            result += input + " ";
        }
        return result;
    }

    static string authorizationFinder(string command)
    {
        int startIndex = command.IndexOf("authorization:");

        if (startIndex == -1)
        {
            return null;
        }

        startIndex += "authorization".Length;

        string endSymbol = "\"";
        int endIndex = command.IndexOf(endSymbol, startIndex);

        if (endIndex == -1)
        {
            return null;
        }

        string cookieValue = command.Substring(startIndex + 2, endIndex - startIndex - 2).Trim();

        return cookieValue;
    }

    static async Task<JObject> HttpRequest_me(string authorization)
    {
        string url = "https://api.spotify.com/v1/me";
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("authorization", authorization);
            HttpResponseMessage response = await client.GetAsync(url);
            JObject jsonObject;
            string content = await response.Content.ReadAsStringAsync();
            jsonObject = JObject.Parse(content);
            return jsonObject;
        }
    }

    static async Task<JObject> HttpRequest_followers(string authorization, string id)
    {
        string url = "https://spclient.wg.spotify.com/user-profile-view/v3/profile/" + id + "/followers?market=from_token";
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("authorization", authorization);
            HttpResponseMessage response = await client.GetAsync(url);
            JObject jsonObject;
            string content = await response.Content.ReadAsStringAsync();
            jsonObject = JObject.Parse(content);
            return jsonObject;
        }
    }

    static async Task<JObject> HttpRequest_following(string authorization, string id)
    {
        string url = "https://spclient.wg.spotify.com/user-profile-view/v3/profile/" + id + "/following?market=from_token";
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("authorization", authorization);
            HttpResponseMessage response = await client.GetAsync(url);
            JObject jsonObject;
            string content = await response.Content.ReadAsStringAsync();
            jsonObject = JObject.Parse(content);
            return jsonObject;
        }
    }

}