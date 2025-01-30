namespace CodeQualityAnalyzer 
{
    /// <summary>
    /// Core analyzer class that coordinates the analysis of source code files.
    /// Manages multiple metric calculators and aggregates their results.
    /// </summary>
    /// <remarks>
    /// The analyzer:
    /// - Recursively processes all .cs files in the specified directory
    /// - Applies multiple code quality metrics to each file
    /// - Aggregates results for reporting
    /// </remarks>
    public class CodeAnalyzer
    {
        private readonly List<IMetricCalculator> _metricCalculators;

        public CodeAnalyzer()
        {
            _metricCalculators = new List<IMetricCalculator>
            {
                new CyclomaticComplexityCalculator(),
                new CodeDuplicationCalculator(),
                new DependencyDepthCalculator(),
                new ModuleSizeCalculator(),
                new ParameterCountCalculator()
            };
        }

        /// <summary>
        /// Analyzes all source code files in the specified directory and its subdirectories.
        /// </summary>
        /// <param name="path">Root directory path to analyze</param>
        /// <returns>Analysis results for all processed files</returns>
        public AnalysisResults AnalyzeDirectory(string path)
        {
            var results = new AnalysisResults();
            var files = Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var fileContent = File.ReadAllText(file);
                var fileResults = AnalyzeFile(fileContent);
                results.AddFileResults(file, fileResults);
            }

            return results;
        }

        private FileAnalysisResults AnalyzeFile(string content)
        {
            var results = new FileAnalysisResults();

            foreach (var calculator in _metricCalculators)
            {
                var metric = calculator.Calculate(content);
                results.AddMetric(metric);
            }

            return results;
        }
    }
}