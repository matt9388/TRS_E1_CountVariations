using Newtonsoft.Json;

namespace TRS_E1_CountVariations
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"flavors.json"; //Json file in root output to bin.
			List<Flavors>? flavors = JsonConvert.DeserializeObject<List<Flavors>>(File.ReadAllText(filePath)); //Read Json file into list of Flavors object.

			//Using Linq to group all flavors together and get the count of each combination.
			var result = flavors.GroupBy(x => new { x.FlavorOne, x.FlavorTwo, x.FlavorThree }).Select(x => new { f1 = x.Key.FlavorOne, f2 = x.Key.FlavorTwo, f3 = x.Key.FlavorThree, total = x.Count() });

			Console.WriteLine("{0,-50} {1}", " Combination", " Times Eaten");
			Console.WriteLine(new string('-', 65));
			foreach (var item in result)
			{
				Console.WriteLine("{0,-50} {1}", (" " + item.f1 + ", " + item.f2 + ", " + item.f3), "| " + item.total);
			}
			Console.Read();
		}
	}
}