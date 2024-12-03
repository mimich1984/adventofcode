namespace AOC2024;

internal class Day1
{
    public static void Run()
    {
        Console.WriteLine("Day 1");
        var rawData = File.ReadAllLines("./input/day1.txt");
        var list1 = new List<int>();
        var list2 = new List<int>();
        foreach (var line in rawData)
        {
            var items = line.Split("   ");
            list1.Add(int.Parse(items[0]));
            list2.Add(int.Parse(items[1]));
        }

        var orderedList1 = list1.OrderBy(x => x).ToList();
        var orderedList2 = list2.OrderBy(x => x).ToList();

        var distance = 0;
        for (int i = 0; i < orderedList1.Count; i++)
        {
            distance += Math.Abs(orderedList1[i] - orderedList2[i]);
        }

        Console.WriteLine($"Distance = {distance}");

        var similarityList = new List<int>();
        foreach (var item in list1)
        {
            similarityList.Add(item * list2.Where(i => i == item).Count());
        }
        var similarity = similarityList.Sum();

        Console.WriteLine($"Similarity = {similarity}");
    }
}