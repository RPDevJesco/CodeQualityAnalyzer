using System.Text.RegularExpressions;

namespace CodeQualityAnalyzer
{
    /// <summary>
    /// Calculates the cyclomatic complexity of code by analyzing control flow structures.
    /// Complexity measures the number of linearly independent paths through code.
    /// </summary>
    /// <remarks>
    /// The calculator counts:
    /// - If statements
    /// - Loop constructs (while, for)
    /// - Case statements
    /// - Logical operators (&amp;&amp;, ||)
    /// - Conditional operators (?)
    /// 
    /// High complexity (>15) often indicates:
    /// - Code that's difficult to test
    /// - Higher risk of bugs
    /// - Need for refactoring into smaller methods
    /// </remarks>
    public class CyclomaticComplexityCalculator : IMetricCalculator
    {
        /// <summary>
        /// Calculates cyclomatic complexity for the given code content.
        /// </summary>
        /// <param name="content">Source code to analyze</param>
        /// <returns>Complexity metric with threshold of 15</returns>
        public Metric Calculate(string content)
        {
            var complexity = 1; // Base complexity
            
            var decisions = new[]
            {
                @"\bif\b",
                @"\bwhile\b",
                @"\bfor\b",
                @"\bcase\b",
                @"&&",
                @"\|\|",
                @"\?"
            };

            foreach (var pattern in decisions)
            {
                complexity += Regex.Matches(content, pattern).Count;
            }

            return new Metric
            {
                Name = "CyclomaticComplexity",
                Description = "Measures code complexity based on the number of decision points. " +
                            "High complexity indicates code that may be difficult to test and maintain. " +
                            "Consider breaking complex methods into smaller, focused pieces.",
                Value = complexity,
                Threshold = 15,
                IsPassing = complexity <= 15
            };
        }
    }
}