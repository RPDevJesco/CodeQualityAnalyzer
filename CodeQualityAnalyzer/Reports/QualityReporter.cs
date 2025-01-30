namespace CodeQualityAnalyzer
{
    /// <summary>
    /// Generates human-readable reports from analysis results.
    /// Formats and displays metrics for each analyzed file.
    /// </summary>
    public class QualityReporter
    {
        /// <summary>
        /// Generates and displays a console report of analysis results
        /// </summary>
        /// <param name="results">Analysis results to report</param>
        public void GenerateReport(AnalysisResults results)
        {
            Console.WriteLine("Code Quality Analysis Report");
            Console.WriteLine("===========================");

            foreach (var fileResult in results.GetResults())
            {
                Console.WriteLine($"\nFile: {fileResult.Key}");
                Console.WriteLine("-------------------");

                foreach (var metric in fileResult.Value.Metrics)
                {
                    var status = metric.IsPassing ? "✓" : "✗";
                    Console.WriteLine($"{status} {metric.Name}: {metric.Value:F2} (Threshold: {metric.Threshold})");
                    
                    // Only show description for failing metrics
                    if (!metric.IsPassing)
                    {
                        Console.WriteLine($"   {metric.Description}");
                    }
                }
            }
        }
    }
}