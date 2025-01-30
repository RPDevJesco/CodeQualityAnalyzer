namespace CodeQualityAnalyzer
{
    /// <summary>
    /// Represents a single code quality metric calculation result.
    /// Contains the metric name, value, threshold, and pass/fail status.
    /// </summary>
    public class Metric
    {
        /// <summary>
        /// Name of the metric (e.g., "CyclomaticComplexity")
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Human-readable description of what the metric measures and how to interpret it
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Calculated value for the metric
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Threshold value that determines pass/fail status
        /// </summary>
        public double Threshold { get; set; }

        /// <summary>
        /// Indicates whether the metric value is within acceptable limits
        /// </summary>
        public bool IsPassing { get; set; }
    }
}