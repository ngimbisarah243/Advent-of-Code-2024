var input = File.ReadAllLines("C:\\ProgrammingStuff\\AOC_2024\\day_5\\input.txt");
var isNumRow = false;

var output = "";


foreach (var line in input)
{
	if (!String.IsNullOrEmpty(line) && isNumRow == false)
	{
		continue;
	}
	else if (String.IsNullOrWhiteSpace(line)) { isNumRow = true; continue; }
	if (isNumRow)
	{

		if (!isValidLine(line, input))
		{
			output += Correct(line, input) + "\n";
		}
	}



}
int sum = 0;
var arr = output.Split('\n');

foreach (var line in arr)
{
	var index = (line.Length / 2) + 0.5;
	if (string.IsNullOrWhiteSpace(line)) { continue; }

	var length = line.Split(',').Length;

	var middle = (int)Math.Floor((length - 1) / 2.0 + 0.5);

	sum += int.Parse(line.Split(',')[middle]);
}

Console.WriteLine(sum);


string Correct(string row, string[] input)
{
	var zahlen = row.Split(',');
	bool swapped = false;

	do
	{
		swapped = false;
		foreach (var line in input)
		{
			if (string.IsNullOrWhiteSpace(line)) { break; }
			var x = line.Split('|')[0];
			var y = line.Split('|')[1];

			if (zahlen.Contains(x) && zahlen.Contains(y))
			{
				var indexX = Array.IndexOf(zahlen, x);
				var indexY = Array.IndexOf(zahlen, y);
				if (indexX > indexY)
				{

					var temp = zahlen[indexX];
					zahlen[indexX] = zahlen[indexY];
					zahlen[indexY] = temp;
					swapped = true;

				}

			}
		}
	}
	while (swapped);

	if (!isValidLine(string.Join(",", zahlen), input))
	{
		throw new Exception("Sortierung nicht korrekt!");
	}

	return string.Join(",", zahlen);

}



bool isValidLine(string row, string[] input)
{
	var zahlen = row.Split(',');

	foreach (var line in input)
	{
		if (string.IsNullOrWhiteSpace(line)) { break; }
		var x = line.Split('|')[0];
		var y = line.Split('|')[1];


		if (zahlen.Contains(x) && zahlen.Contains(y))
		{
			if (Array.IndexOf(zahlen, x) > Array.IndexOf(zahlen, y))
			{
				return false;
			}
		}
	}
	return true;

}

