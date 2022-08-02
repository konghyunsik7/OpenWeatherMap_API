using Newtonsoft.Json.Linq;

//

var client = new HttpClient();

string apiJson = File.ReadAllText("appsettings.json");
string apiKey = JObject.Parse(apiJson).GetValue("DefaultKey").ToString();


Console.WriteLine("Please give me a 5 digit zipcode");
int userInput = int.Parse(Console.ReadLine());

var openWeatherMap = $"https://api.openweathermap.org/data/2.5/weather?zip={userInput},US&appid={apiKey}";


var jsonResponse = client.GetStringAsync(openWeatherMap).Result;

var openWeatherObject = JObject.Parse(jsonResponse);

Console.WriteLine(openWeatherObject);


double inputCity = double.Parse(openWeatherObject["main"]["feels_like"].ToString());

Console.WriteLine(inputCity); 