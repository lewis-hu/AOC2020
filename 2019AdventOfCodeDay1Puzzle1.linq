<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
</Query>

static async Task Main()
{

	//var multiLineInput = await GetPuzzleInputAsync();  //let's not hammer the poor hosting site
	//multiLineInput.Dump();
	//return;
	var multiLineInput = await GetPuzzleInputOffline();
	//multiLineInput.Dump();
	//return;
	var inputList = multiLineInput.Split(new string[] { "\n" }, StringSplitOptions.None);
	//inputList.Count().Dump("Count");

	var validCount = 0;
	var fuelRequired = 0;
	var sumFuelRequired = 0;
	foreach (var input in inputList)
	{   
		var intInput = int.Parse(input);
		fuelRequired = GetFuelRequired(intInput);
		fuelRequired.Dump();
		sumFuelRequired += fuelRequired;
	}
	sumFuelRequired.Dump("sum");
}

public static int GetFuelRequired(int input)
{
	var fuelRequired = Math.Max(0, Convert.ToInt32(Math.Floor(input / 3m)) - 2);
	if(fuelRequired > 0)
	{
		return fuelRequired += GetFuelRequired(fuelRequired);
	}
	return 0;
	
}

// You can define other methods, fields, classes and namespaces here
public static async Task<string> GetPuzzleInputAsync()
{
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
		response = await client.GetAsync("2019/day/1/input");

		// Verification  
		if (response.IsSuccessStatusCode)
		{
			// Reading Response.  

			result = await response.Content.ReadAsStringAsync();

		}
	}
	return result;
}

public static async Task<string> GetPuzzleInputOffline()
{
	return await Task.FromResult(@"50062
118298
106698
59751
59461
144411
52783
118293
148025
54354
95296
68478
80105
76390
75768
89311
117129
127515
131531
127565
77249
91806
123811
123508
127263
61076
82153
122561
89117
116790
146530
66706
56549
112264
139250
87331
144022
142052
125519
89797
85148
125388
67458
116066
74346
148163
55477
146163
99308
95653
122175
92021
146532
109749
136711
102321
114221
140294
116718
127416
130402
52239
125181
146410
126339
147221
81706
80131
140909
59935
71878
64434
148450
73037
90890
137135
85992
137381
84604
62524
64133
92067
124269
132039
145257
107367
62143
105000
62124
55929
101489
94728
85982
88358
83275
132648
75688
109263
146400
114701");
}
