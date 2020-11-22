using Newtonsoft.Json;
using SharedLib.Responses;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            ConfigureHttpClient();

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
                    case 2:
                        await GetSearchJokeAsync();
                        break;
                    default:
                        Console.WriteLine("Nope");
                        break;
                }
            }
        }

        private static void ConfigureHttpClient()
        {
            client.BaseAddress = new Uri("https://localhost:44330/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
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

        private static int GetMainMenuOption()
        {
            var current = Console.ForegroundColor;

            Console.WriteLine("Make a selection below, and prepare to laugh!");
            Console.WriteLine("\r\n\r\n1. Show me a random joke");
            Console.WriteLine("2. Let me provide a term, and then show me what you got");
            Console.WriteLine("0. We're done here! I cannot take any more! Exit me!");
            Console.Write("\r\n\r\nMake your selection wisely: ");
            var selection = Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\r\nStand by! Incoming comedic material...\r\n");
            Console.ForegroundColor = current;

            if (int.TryParse(selection.KeyChar.ToString(), out int result))
            {
                return result;
            }
            Console.Write("haha... funny... Now, select a VALID option! :)");
            return GetMainMenuOption();
        }

        private static async Task GetSearchJokeAsync()
        {
            var current = Console.ForegroundColor;
            ShowTitle();
            Console.WriteLine("Ah, I see... we want to be subjective on the jokes. OK...");
            var searchTerm = GetSearchTerm();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\r\nOK... lets go through my list of comedy genius... Hang on...\r\n");
            Console.ForegroundColor = current;


            HttpResponseMessage response = await client.GetAsync($"/joke/{searchTerm}/30");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var jokes = JsonConvert.DeserializeObject<DadJokeListResponse>(json);

            if(jokes.Data.Count == 0)
            {
                Console.WriteLine($"\r\nAw what?! I have no material that relates to the term, {searchTerm}! That's not good. Maybe try something else.");
            }
            else
            {
                Console.WriteLine($"\r\nI've got some good stuff about the term, {searchTerm}. Prepare for a belly laugh!\r\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var joke in jokes.Data)
                {
                    Console.WriteLine(joke.Joke);
                }
                Console.ForegroundColor = current;
                Console.WriteLine("\r\n\r\nAnd I have PLENTY more where those came from!");
            }

            Console.WriteLine("\r\n\r\nPress a key and we can try something else?");
            Console.ReadKey();

        }

        private static string GetSearchTerm()
        {
            var current = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\r\nEnter a word, and I'll see if I can get you a few jokes based on in: ");
            Console.ForegroundColor = current;
            var term = Console.ReadLine();
            if (string.IsNullOrEmpty(term))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\r\n\r\nYeahh..... you're going to have to give me more to go on that that!");
                Console.ForegroundColor = current;
                return GetSearchTerm();
            }
            return term;
        }

        private static async Task GetRandomJokeAsync()
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
