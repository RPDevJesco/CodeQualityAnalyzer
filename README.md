1. Intrinsic Code Quality (Language-Agnostic Metrics)

These criteria are measurable without relying on linters, static analysis tools, or subjective judgment:
Criterion	Objective Measurement
Cyclomatic Complexity	Calculate via formula (edges - nodes + 2). Threshold: <15 per function/method. Higher values indicate overly complex logic.
Code Duplication	Measure via clone detection (e.g., token-based comparison). Threshold: <5% duplicated code.
Dependency Depth	Count nested conditionals/loops (e.g., >3 levels deep fails).
Function/Module Size	Lines of Code (LOC): <50 lines per function, <500 lines per module.
Parameter Count	Function arguments: <4 parameters (exceptions for data objects).
Error Rate	Track defects per module (e.g., bugs reported in production). Threshold: <0.1 defects per 100 LOC.
Code Churn	Frequency of changes to a module (via version control). High churn suggests instability.
Test Failure Rate	Automated test pass rate: ≥95% for critical paths.
Performance Benchmarks	Measure latency/throughput against requirements (e.g., API response <500ms).
Code Entropy	Measure frequency of changes (via Git history). High entropy suggests unpredictable code.
2. Eliminating Subjectivity in Design

Replace ambiguous terms like "readable" or "maintainable" with quantifiable proxies:

    Naming Consistency:

        Use a dictionary check for variable/function names (e.g., calculateRevenue(), not calcRev()).

        Enforce a glossary of domain terms (e.g., "user" vs. "customer").

    Coupling/Cohesion:

        Count cross-module dependencies (e.g., imports/calls). Threshold: <10 dependencies per module.

        Group related functions/classes in the same directory.

    Documentation Completeness:

        Require docstrings for all public APIs (measured via tooling like Doxygen).

        Missing docs = automatic failure.

3. Security & Reliability (Zero Tolerance)

    Known Vulnerabilities:

        Use CVE databases (e.g., NVD) to block dependencies with CVSS scores ≥7.0.

    Input Validation:

        All external inputs (APIs, files, user inputs) must have explicit validation checks.

        Fail code reviews if validation is missing.

    Failure Modes:

        Code must handle edge cases (e.g., empty lists, nulls, network timeouts).

        Prove via unit tests (e.g., 100% coverage for error-handling paths).

4. Pragmatic Thresholds

Define pass/fail thresholds for metrics and enforce them automatically:

    Cyclomatic Complexity >15: Refactor or reject.

    Code Duplication >5%: Reject until deduplicated.

    Untested Error Paths: Block deployment.

    Dependencies with CVEs: Block CI/CD pipelines.

5. Avoiding Tooling Dependencies

If static analysis tools aren’t available:

    Manual Metric Calculation:

        Use version control (e.g., Git) to track code churn/defect correlation.

        Scripts to count LOC, parameters, or nested blocks.

    Checklists:

        Enforce criteria via pre-merge checklists (e.g., "Does this function have >4 parameters? Yes/No").

6. Contextual Flexibility

Adjust thresholds based on domain-specific needs (e.g., aerospace vs. a startup MVP):

    Safety-Critical Systems: Stricter complexity/duplication thresholds.

    Prototypes: Relax thresholds but enforce error handling.

Conclusion

Good code meets objectively measurable thresholds for complexity, duplication, error handling, and security. Bad code violates these thresholds, increasing risk of defects or maintenance costs. By focusing on intrinsic properties (e.g., complexity, duplication, defect rates) rather than subjective opinions or tooling, teams can enforce rigor even in environments with limited infrastructure.

Objectivity: The tool uses concrete, measurable metrics rather than subjective assessments, with specific numeric thresholds for each measure.
Key Metrics and Thresholds:


1. Code Duplication: Identifies repeated blocks of 6 or more lines (MinimumDuplicateLength = 6)
2. Cyclomatic Complexity: Fails if complexity exceeds 15 (counts if, while, for, case, &&, ||, ?)
3. Dependency Depth: Fails if nesting depth exceeds 3 levels (if, while, for, switch statements)
4. Module Size: Fails if file exceeds 500 non-empty lines
5. Parameter Count: Fails if any method has more than 4 parameters
