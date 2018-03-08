using System;
using System.Reflection;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Translation.V2;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

class Translate
{
    public async Task<string> Handler(string input, ILambdaContext context)
    {
        using (var key = Assembly.GetExecutingAssembly().GetManifestResourceStream("i5n.gcp.json"))
        {
            var credential = GoogleCredential.FromStream(key);
            var client = TranslationClient.Create(credential);
            var result = await client.TranslateTextAsync(input, LanguageCodes.Italian);
            return result.TranslatedText;
        }
    }
}