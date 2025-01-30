namespace CodeQualityAnalyzer
{
    /// <summary>
    /// Main entry point for the Code Quality Analyzer application.
    /// Processes command-line arguments and orchestrates the analysis process.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: CodeQualityAnalyzer <path-to-source-directory>");
                return;
            }

            var analyzer = new CodeAnalyzer();
            var results = analyzer.AnalyzeDirectory(args[0]);
            var reporter = new QualityReporter();
            reporter.GenerateReport(results);
        }
    }
}