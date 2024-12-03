namespace AOC2024;

using Microsoft.Extensions.Logging;

public class Day2(ILogger<Day2> logger, string[] rawData)
{
    private ILogger<Day2> _logger = logger ?? throw new ArgumentException(nameof(logger));
    private readonly string[] _rawData = rawData ?? throw new ArgumentNullException(nameof(rawData));

    internal List<int[]> GetReportList()
    {
        var reportList = new List<int[]>();
        foreach (var report in _rawData)
        {
            var items = report.Split(" ");
            var reportItems = new int[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                reportItems[i] = int.Parse(items[i]);
            }
            reportList.Add(reportItems);
        }
        return reportList;
    }

    internal bool IsReportSafe(int[] report)
    {
        bool safeDiff = true;
        bool isIncreasing = false;
        bool isDecreasing = false;
        for (int i = 0; i < report.Length - 2; i++)
        {
            var diff = Math.Abs(report[i] - report[i + 1]);
            if (report[i] < report[i + 1])
            {
                isIncreasing = true;
            }
            if (report[i] > report[i + 1])
            {
                isDecreasing = true;
            }
            if (diff < 1 || diff > 3)
            {
                safeDiff = false;
            }
        }
        return safeDiff && (isIncreasing ^ isDecreasing);
    }

    public int Run()
    {
        var reportList = GetReportList();
        var safeCount = 0;
        foreach (var report in reportList)
        {
            safeCount += IsReportSafe(report) ? 1 : 0;
        }

        return safeCount;
    }
}