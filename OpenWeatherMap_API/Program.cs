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


double inputCityFeelsLike = double.Parse(openWeatherObject["main"]["feels_like"].ToString());

double newFeelsLike = 1.8 * (inputCityFeelsLike - 273) + 32;

string zipcodeCityName = openWeatherObject["name"].ToString();

string weatherDescription = openWeatherObject["weather"].First["description"].ToString();



// temp conversion equation (kelvin to F) = 1.8 * (K - 273) + 32  //

double tempChange = double.Parse(openWeatherObject["main"]["temp"].ToString());

double newTempToFahrenheit = 1.8 * (tempChange - 273) + 32;


Console.WriteLine($"You searched for: {zipcodeCityName}");
Console.WriteLine($"Your temperature is: {Math.Round(newTempToFahrenheit,2)}ºF");
Console.WriteLine($"{zipcodeCityName} feels like: {Math.Round(newFeelsLike,2)}ºF");
Console.WriteLine($"Weather description: {weatherDescription}");

