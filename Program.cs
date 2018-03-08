using System;
using System.Threading.Tasks;
using Google.Cloud.Translation.V2;

namespace i5n
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = TranslationClient.Create();
            var result = await client.TranslateTextAsync(args[0], LanguageCodes.Italian);
            Console.WriteLine(result.TranslatedText);
        }
    }
}
