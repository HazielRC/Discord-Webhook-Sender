using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Discord Webhook Sender by Haziel RC");
        await SendAsync();
    }

    static async Task SendAsync()
    {
        string webhookUrl = "https://discord.com/api/webhooks/1116928299969544354/abmFwXHWvo4CrWTZJ2JjJBZ8WnkPcoKF3mkPJnfv80L7Hxsn0KIOEGZtW-fqXWF94g8S"; // Replace this with your real webhook url

        WebhookBody example = new WebhookBody()
        {
            username = "HazielRC",
            avatar_url = string.Empty,
            content = "@here",
            embeds = new List<Embed>
            {
                new Embed()
                {
                    title = "My Embed",
                    color = 000000,
                    description = "My favorite and fabulous embed!",
                    timestamp = string.Empty,
                    url = string.Empty,
                    author = new Dictionary<string, string>()
                    {
                        { "name", "Test Author" },
                        { "url", "" },
                        { "icon_url", "" }
                    },
                    image = new Dictionary<string, string>()
                    {
                        { "url", "" }
                    },
                    thumbnail = new Dictionary<string, string>()
                    {
                        { "url", "" }
                    },
                    footer = new Dictionary<string, string>()
                    {
                        { "text", "Test footer" }
                    },
                    fields = new List<Field>()
                    {
                        new Field()
                        {
                            name = "Field 1",
                            value = "Field value 1",
                            inline = true
                        }
                    }
                }
            }
        };

        var json = JsonConvert.SerializeObject(example, Formatting.Indented);

        using (var httpClient = new HttpClient())
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(webhookUrl, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Message sended.");
            }
            else
            {
                Console.WriteLine($"Error at message send. Status code: {response.StatusCode}");
            }
        }
    }
}

class WebhookBody
{
    public string username { get; set; }
    public string avatar_url { get; set; }
    public string content { get; set; }
    public List<Embed> embeds { get; set; }
}

class Embed
{
    public string title { get; set; }
    public int color { get; set; }
    public string description { get; set; }
    public string timestamp { get; set; }
    public string url { get; set; }
    public Dictionary<string, string> author { get; set; }
    public Dictionary<string, string> image { get; set; }
    public Dictionary<string, string> thumbnail { get; set; }
    public Dictionary<string, string> footer { get; set; }
    public List<Field> fields { get; set; }
}

class Field
{
    public string name { get; set; }
    public string value { get; set; }
    public bool inline { get; set; }
}
