namespace CodeQualityAnalyzer
{
    /// <summary>
    /// Calculates the maximum nesting depth of control structures in code.
    /// This metric identifies code that may be too deeply nested and therefore difficult to understand and maintain.
    /// </summary>
    /// <remarks>
    /// The calculator tracks:
    /// - Nested if statements
    /// - Nested loops (for, while)
    /// - Switch statements
    /// 
    /// A depth greater than 3 levels often indicates:
    /// - Complex conditional logic that could be simplified
    /// - Potential cognitive overload for developers
    /// - Code that might benefit from extraction into separate methods
    /// </remarks>
    public class DependencyDepthCalculator : IMetricCalculator
    {
        public Metric Calculate(string content)
        {
            var maxDepth = 0;
            var currentDepth = 0;
            var lines = content.Split('\n');

            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                
                if (trimmedLine.StartsWith("if") || 
                    trimmedLine.StartsWith("for") || 
                    trimmedLine.StartsWith("while") ||
                    trimmedLine.StartsWith("switch"))
                {
                    currentDepth++;
                    maxDepth = Math.Max(maxDepth, currentDepth);
                }

                if (trimmedLine.StartsWith("}"))
                {
                    currentDepth--;
                }
            }

            return new Metric
            {
                Name = "DependencyDepth",
                Description = "Measures the maximum nesting depth of control structures (if, for, while, switch). " +
                            "Deep nesting can make code harder to understand and maintain. " +
                            "Consider extracting deeply nested logic into separate methods.",
                Value = maxDepth,
                Threshold = 3,
                IsPassing = maxDepth <= 3
            };
        }
    }
}