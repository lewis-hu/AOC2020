<Query Kind="Program">
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Net.Http.Headers</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static async Task Main()
{
	var input = await File.ReadAllTextAsync(@"C:\code\AdventOfCode\Day6\input.txt");
	List<string> groupList = input.Replace("\r", "").Split("\n\n").ToList();
	int uniqueCount = 0;
	foreach(var group in groupList)
	{
		List<char> uniqueCharList = new List<char>();
		foreach(var ch in group) {
			if(ch != '\n')
			uniqueCharList.Add(ch);
			
		}
		uniqueCount += uniqueCharList.Distinct().Count();

	}
			uniqueCount.Dump();
}
