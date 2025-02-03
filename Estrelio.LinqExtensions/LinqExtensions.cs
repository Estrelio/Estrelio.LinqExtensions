// -----------------------------------------------------------------------
// <copyright file="LinqExtensions.cs" company="Estrelio">
// Copyright (c) Estrelio. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Estrelio.LinqExtensions;

using System.Linq.Expressions;

/// <summary>
/// Linq extensions.
/// </summary>
public static class LinqExtensions
{
    /// <summary>
    /// Filter a sequence of values based on a predicate if a condition is met.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="condition">The condition.</param>
    /// <param name="predicate">The predicate.</param>
    /// <typeparam name="T">The type of the source.</typeparam>
    /// <returns>The filtered sequence.</returns>
    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
    {
        return condition ? source.Where(predicate) : source;
    }

    /// <summary>
    /// Filter a sequence of values based on a predicate if a condition is met.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <param name="condition">The condition.</param>
    /// <param name="predicate">The predicate.</param>
    /// <typeparam name="T">The type of the source.</typeparam>
    /// <returns>The filtered sequence.</returns>
    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> source,
        bool condition,
        Expression<Func<T, bool>> predicate)
    {
        return condition ? source.Where(predicate) : source;
    }
}