# Code Quality Analyzer

A C# tool for objective, metrics-based code quality analysis that helps identify potential issues in your codebase using concrete, measurable criteria.

## Overview

The Code Quality Analyzer evaluates source code against established software engineering metrics, providing objective feedback about code quality without relying on subjective assessments. It analyzes C# source files and reports on various quality metrics with specific, measurable thresholds.

## Metrics

### 1. Cyclomatic Complexity
- **Threshold:** 15
- **What it measures:** The number of linearly independent paths through code
- **What it counts:**
  - if statements
  - while loops
  - for loops
  - case statements
  - Logical operators (&&, ||)
  - Conditional operators (?)
- **Why it matters:** High complexity indicates code that's difficult to test and maintain

### 2. Code Duplication
- **Threshold:** 5% of total lines
- **Minimum block size:** 6 lines
- **What it measures:** Identical blocks of code that might indicate copy-paste programming
- **Why it matters:** Duplication can lead to maintenance problems and inconsistencies

### 3. Dependency Depth
- **Threshold:** 3 levels
- **What it measures:** Nesting depth of control structures
- **What it tracks:**
  - Nested if statements
  - Nested loops
  - Switch statements
- **Why it matters:** Deep nesting makes code harder to understand and maintain

### 4. Module Size
- **Threshold:** 500 lines
- **What it measures:** Number of non-empty lines in a module
- **What it ignores:** Empty lines and whitespace-only lines
- **Why it matters:** Large modules often violate the Single Responsibility Principle

### 5. Parameter Count
- **Threshold:** 4 parameters
- **What it measures:** Number of parameters in method signatures
- **Why it matters:** Methods with many parameters can be hard to use and maintain

## Usage

### Command Line
```bash
CodeQualityAnalyzer.exe <path-to-source-directory>
```

### Example Output
```
Code Quality Analysis Report
===========================

File: Example.cs
-------------------
✓ CyclomaticComplexity: 12.00 (Threshold: 15)
✗ CodeDuplication: 7.50 (Threshold: 5)
   Identifies repeated code blocks of 6 or more lines. 
   Duplication can lead to maintenance problems and inconsistencies. 
   Consider extracting duplicated code into shared methods.
```

## Interpreting Results

The analyzer uses a pass/fail system:
- ✓ (Pass): Metric is within acceptable limits
- ✗ (Fail): Metric exceeds threshold

When a metric fails, the tool provides:
1. The specific value that was calculated
2. The threshold that was exceeded
3. A description of why this metric matters
4. Suggestions for improvement

## Best Practices

When metrics indicate issues:

### High Cyclomatic Complexity
- Break complex methods into smaller, focused pieces
- Extract complex conditions into well-named helper methods
- Consider using the Strategy pattern for complex conditional logic

### Code Duplication
- Extract duplicated code into shared methods
- Consider creating utility classes for common operations
- Use inheritance or composition to share behavior

### Deep Nesting
- Extract nested logic into separate methods
- Consider using early returns to reduce nesting
- Use guard clauses to handle edge cases early

### Large Modules
- Split large classes into smaller, focused classes
- Follow the Single Responsibility Principle
- Consider using partial classes for better organization

### Many Parameters
- Create parameter objects to group related parameters
- Consider builder pattern for complex object construction
- Look for opportunities to reduce method scope

## Technical Details

### Language Support
- Currently supports C# source files only
- File extension: `.cs`
- Processes all matching files in specified directory and subdirectories

### Dependencies
- .NET 9.0
- No external dependencies required

## Future Improvements

Potential areas for enhancement:
1. Support for additional programming languages
2. Configuration options for thresholds
3. HTML report generation
4. Integration with build pipelines
5. Historical trend analysis
6. Additional metrics such as:
   - Error handling coverage
   - Code churn
   - Test coverage
   - Security metrics

## Contributing

When contributing to this project:
1. Ensure all metrics remain objective and measurable
2. Add comprehensive XML documentation for new features
3. Follow existing code organization patterns
4. Include descriptions for any new metrics
5. Maintain the focus on quantifiable quality measures
