1. Intrinsic Code Quality (Language-Agnostic Metrics)
2. Eliminating Subjectivity in Design
3. Security & Reliability (Zero Tolerance)
4. Pragmatic Thresholds
5. Avoiding Tooling Dependencies
6. Contextual Flexibility

Objectivity: The tool uses concrete, measurable metrics rather than subjective assessments, with specific numeric thresholds for each measure.
Key Metrics and Thresholds:


1. Code Duplication: Identifies repeated blocks of 6 or more lines (MinimumDuplicateLength = 6)
2. Cyclomatic Complexity: Fails if complexity exceeds 15 (counts if, while, for, case, &&, ||, ?)
3. Dependency Depth: Fails if nesting depth exceeds 3 levels (if, while, for, switch statements)
4. Module Size: Fails if file exceeds 500 non-empty lines
5. Parameter Count: Fails if any method has more than 4 parameters
