using Newtonsoft.Json;
using SharedLib.Responses;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("https://localhost:44330/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            bool more = true;

            while (more)
            {
                ShowTitle();
                var reply = GetMainMenuOption();
                switch (reply)
                {
                    case 0:
                        more = false;
                        break;
                    case 1:
                        await GetRandomJokeAsync();
                        break;
                    default:
                        Console.WriteLine("Nope");
                        break;
                }
            }
        }


        static void ShowTitle()
        {
            Console.Clear();
            var current = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"    ____                                __");
            Console.WriteLine(@"   / __ \___  ____ _________  ___  ____/ / ");
            Console.WriteLine(@"  / / / / _ \/ __ `/ ___/ _ \/ _ \/ __  / ");
            Console.WriteLine(@" / /_/ /  __/ /_/ / /  /  __/  __/ /_/ / ");
            Console.WriteLine(@"/_____/\___/\__, /_/   \___/\___/\__,_/ ");
            Console.WriteLine(@"           /____/");
            Console.WriteLine("\r\n\r\n");
            Console.ForegroundColor = current;
            
        }

        static int GetMainMenuOption()
        {
            var current = Console.ForegroundColor;
            Console.WriteLine("Make a selection below, and prepare to laugh!");
            Console.WriteLine("\r\n\r\n1. Show me a random joke");
            Console.WriteLine("2. Let me provide a term, and then show me what you got");
            Console.WriteLine("0. We're done here! I cannot take any more! Exit me!");
            Console.Write("\r\n\r\nMake your selection wisely: ");
            var selection = Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\r\nStand by! Incoming comedic material...");
            Console.ForegroundColor = current;

            if(int.TryParse(selection.KeyChar.ToString(), out int result))
            {
                return result;
            }
            Console.Write("\r\nhaha... funny... Now, select a VALID option! :)");
            return GetMainMenuOption();
        }

        static async Task GetRandomJokeAsync()
        {
            var current = Console.ForegroundColor;
            try
            {
                HttpResponseMessage response = await client.GetAsync($"/joke");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var joke = JsonConvert.DeserializeObject<DadJokeResponse>(json);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\r\n\r\n" + joke.Data.Joke);

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"This is no joke! The funny stuff, broke! Probably because a connection cannot be made to the api. Call the clown that wrote this, and give him this message:\r\n\r\n{e.Message}");
            }
            Console.ForegroundColor = current;

            Console.WriteLine("\r\n\r\nHahah! Press a key to make another selection...");
            Console.ReadKey();

        }


    }
}
