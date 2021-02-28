using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace CraftRise_Sample_API
{
    class Program
    {
        static string LoginAPI = "https://www.craftrise.com.tr/posts/post-login.php";
        static string value;
        static string password;
        static void Main(string[] args)
        {
            Console.Write("Kullanıcı adı : ");
            value = Console.ReadLine();
            Console.Write("Parola : ");
            password = Console.ReadLine();

            Task.Run((Login));
            Console.Read();
        }
        public static async Task Login()
        {
            HttpClient client = new HttpClient();

            var formContent = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("value", value),
            new KeyValuePair<string, string>("password", password)
            });

            var pst = await client.PostAsync(LoginAPI, formContent);

            var stringContent = await pst.Content.ReadAsStringAsync();

            Console.Write(stringContent);

        }
    }
}
