namespace CodeQualityAnalyzer
{
    /// <summary>
    /// Contains analysis results for a single source code file.
    /// Aggregates multiple metric calculations.
    /// </summary>
    public class FileAnalysisResults
    {
        /// <summary>
        /// Collection of metrics calculated for this file
        /// </summary>
        public List<Metric> Metrics { get; } = new List<Metric>();

        /// <summary>
        /// Adds a new metric calculation result
        /// </summary>
        public void AddMetric(Metric metric)
        {
            Metrics.Add(metric);
        }
    }
}