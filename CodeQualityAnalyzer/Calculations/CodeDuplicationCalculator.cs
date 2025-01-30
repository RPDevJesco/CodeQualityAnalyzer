namespace CodeQualityAnalyzer
{
    /// <summary>
    /// Analyzes source code for duplicate code blocks that might indicate copy-paste programming.
    /// Identifies opportunities for refactoring and code reuse.
    /// </summary>
    /// <remarks>
    /// The calculator:
    /// - Identifies blocks of identical code (minimum 6 lines)
    /// - Calculates duplication as a percentage of total lines
    /// - Flags files with >5% duplication
    /// 
    /// High duplication suggests:
    /// - Potential for creating shared methods
    /// - Risk of inconsistent updates
    /// - Maintenance challenges
    /// </remarks>
    public class CodeDuplicationCalculator : IMetricCalculator
    {
        private const int MinimumDuplicateLength = 6;

        public Metric Calculate(string content)
        {
            var lines = content.Split('\n');
            var duplicateLines = 0;
            var windowSize = MinimumDuplicateLength;

            for (int i = 0; i <= lines.Length - windowSize; i++)
            {
                var window = string.Join("\n", lines.Skip(i).Take(windowSize));
                var remainingContent = string.Join("\n", lines.Skip(i + windowSize));

                if (remainingContent.Contains(window))
                {
                    duplicateLines += windowSize;
                    i += windowSize - 1;
                }
            }

            var duplicationRate = (double)duplicateLines / lines.Length * 100;

            return new Metric
            {
                Name = "CodeDuplication",
                Description = "Identifies repeated code blocks of 6 or more lines. " +
                              "Duplication can lead to maintenance problems and inconsistencies. " +
                              "Consider extracting duplicated code into shared methods.",
                Value = duplicationRate,
                Threshold = 5,
                IsPassing = duplicationRate <= 5
            };
        }
    }
}