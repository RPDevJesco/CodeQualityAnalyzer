namespace CodeQualityAnalyzer
{
    /// <summary>
    /// Defines the contract for metric calculators that analyze specific aspects of code quality.
    /// </summary>
    public interface IMetricCalculator
    {
        /// <summary>
        /// Calculates a specific metric for the given source code content.
        /// </summary>
        /// <param name="content">Source code to analyze</param>
        /// <returns>Calculated metric with value and pass/fail status</returns>
        Metric Calculate(string content);
    }
}