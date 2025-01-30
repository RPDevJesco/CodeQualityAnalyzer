namespace CodeQualityAnalyzer
{
    /// <summary>
    /// Aggregates analysis results for multiple files.
    /// Provides access to file-level and overall project metrics.
    /// </summary>
    public class AnalysisResults
    {
        private readonly Dictionary<string, FileAnalysisResults> _fileResults 
            = new Dictionary<string, FileAnalysisResults>();

        /// <summary>
        /// Adds analysis results for a specific file
        /// </summary>
        public void AddFileResults(string filePath, FileAnalysisResults results)
        {
            _fileResults[filePath] = results;
        }

        /// <summary>
        /// Retrieves all file analysis results
        /// </summary>
        public IReadOnlyDictionary<string, FileAnalysisResults> GetResults()
        {
            return _fileResults;
        }
    }
}