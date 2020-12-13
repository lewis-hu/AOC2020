<Query Kind="Program">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


public static async Task<string> GetPuzzleInputAsync(int DayNumber)
{
	var filePath = $@"C:\code\AdventOfCode\Day{DayNumber}\input.txt";
	if (File.Exists(filePath))
	{
		return await File.ReadAllTextAsync(filePath);
	}

	// Initialization.  
	List<string> puzzleInput = new List<string>();
	const string sessionCookie = "_ga=GA1.2.918020773.1606803859; _gid=GA1.2.1131951502.1606803859; ru=53616c7465645f5f40ba35026abee564eec17100e741144c4fd294b2d652f987e0e66a05f3d536ffbb893d36ebc954d3; session=53616c7465645f5f30362387c56a05404f21b59f522335f1fbf01d028a480a5a68be90f0f00b4cd064e548429d869b7b; _gat=1";
	// HTTP GET.  
	string result = string.Empty;
	using (var client = new HttpClient())
	{
		// Setting Base address.  
		client.BaseAddress = new Uri("https://adventofcode.com/");

		// Setting content type.  
		client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
		client.DefaultRequestHeaders.Add("Cookie", sessionCookie);

		// Initialization.  
		HttpResponseMessage response = new HttpResponseMessage();

		// HTTP GET  
		response = await client.GetAsync($"2020/day/{DayNumber}/input");

		// Verification  
		if (response.IsSuccessStatusCode)
		{
			// Reading Response.  
			result = await response.Content.ReadAsStringAsync();
			result.Replace("\r", "").Replace("\n\n","\n");
			System.IO.File.WriteAllText(filePath, result);
		}
		return result;
	}
}
public static async Task<string> GetTestInputAsync(int DayNumber)
{
	var filePath = $@"C:\code\AdventOfCode\Day{DayNumber}\test.txt";
	if (File.Exists(filePath))
	{
		return await File.ReadAllTextAsync(filePath);
	}
	return string.Empty;

}
