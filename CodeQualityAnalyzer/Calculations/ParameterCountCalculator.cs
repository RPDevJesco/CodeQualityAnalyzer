using System.Text.RegularExpressions;

namespace CodeQualityAnalyzer
{
    /// <summary>
    /// Analyzes method parameter counts to identify potential design issues.
    /// Methods with too many parameters often indicate poor encapsulation or the need for parameter objects.
    /// </summary>
    /// <remarks>
    /// The calculator:
    /// - Counts parameters in method signatures
    /// - Identifies methods exceeding 4 parameters
    /// - Suggests refactoring approaches
    /// 
    /// High parameter counts often indicate:
    /// - Poor encapsulation
    /// - Methods doing too much
    /// - Need for parameter objects
    /// </remarks>
    public class ParameterCountCalculator : IMetricCalculator
    {
        public Metric Calculate(string content)
        {
            var methodPattern = @"(\w+)\s+(\w+)\s*\((.*?)\)";
            var matches = Regex.Matches(content, methodPattern);
            var maxParameters = 0;

            foreach (Match match in matches)
            {
                var parameters = match.Groups[3].Value.Split(',');
                maxParameters = Math.Max(maxParameters, parameters.Length);
            }

            return new Metric
            {
                Name = "ParameterCount",
                Description = "Tracks the maximum number of parameters in any method. " +
                              "Methods with many parameters can be hard to use and maintain. " +
                              "Consider using parameter objects or breaking down complex methods.",
                Value = maxParameters,
                Threshold = 4,
                IsPassing = maxParameters <= 4
            };
        }
    }
}