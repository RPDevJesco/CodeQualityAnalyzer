namespace CodeQualityAnalyzer
{
    /// <summary>
    /// Calculates the size of a module by counting non-empty lines of code.
    /// This metric helps identify modules that may be too large and should be split into smaller, more focused units.
    /// </summary>
    /// <remarks>
    /// The calculator:
    /// - Counts all non-whitespace lines in the file
    /// - Uses a threshold of 500 lines (based on common practices)
    /// - Ignores empty lines and whitespace-only lines
    /// 
    /// Large modules often indicate:
    /// - Multiple responsibilities (violating SRP)
    /// - Potential maintenance challenges
    /// - Need for splitting into smaller, focused modules
    /// </remarks>
    public class ModuleSizeCalculator : IMetricCalculator
    {
        public Metric Calculate(string content)
        {
            var lines = content.Split('\n')
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Count();

            return new Metric
            {
                Name = "ModuleSize",
                Description = "Counts the number of non-empty lines in a module. " +
                              "Large modules may have too many responsibilities. " +
                              "Consider splitting modules larger than 500 lines into smaller, focused units.",
                Value = lines,
                Threshold = 500,
                IsPassing = lines <= 500
            };
        }
    }
}