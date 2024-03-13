using System.Text.Json;
using ConsoleApp6;
using LaunchDarkly.Sdk;
using LaunchDarkly.Sdk.Json;
using LaunchDarkly.Sdk.Server;

const string LaunchDarklySdkKey = "sdk-89ba6dfe-dfb0-4a1f-b6ec-a5d38791ca53";// "sdk-18a7603f-38d1-4337-a9cb-412d7eadefa7";
const string speedShipKey = "auto-docs-use-speedship-configurations"; // "auto-docs-use-speedship-configuration";

var _launchDarklyClient = new LdClient(LaunchDarklySdkKey);

//LdJsonSerialization.SerializeObject()
try
{
    var person = Get<Person?>(speedShipKey, new Person{Name = "test"});
    Console.WriteLine(person?.Name);
    Console.WriteLine("Hello World!");
   
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

return;


T Get<T>(string key, T defaultValue, string userKey = "")
{
    var user = User.WithKey(userKey);
    
    var parsedDefaultValue = LdValue.Parse(JsonSerializer.Serialize(defaultValue));
    
    var ldValue = _launchDarklyClient.JsonVariation(key, user, parsedDefaultValue);
    
    if (ldValue.Count == 0)
    {
        return defaultValue;
    }
    
    return JsonSerializer.Deserialize<T>(
        LdJsonSerialization.SerializeObject(ldValue),
        new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    }) ?? defaultValue;
}