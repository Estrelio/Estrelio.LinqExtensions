# Estrelio.LinqExtensions

Contains extension methods for LINQ

- `WhereIf(condition, predicate)` filters an `IEnumerable<T>` or `IQueryable<T>` only when the condition is met.
- `IncludeIf(condition, navigation)` adds an EF Core `Include` (optionally filtered with `Where`) to an `IQueryable<T>`
  only when the condition is met. It returns `IQueryable<T>`, so it cannot be followed by `ThenInclude`.