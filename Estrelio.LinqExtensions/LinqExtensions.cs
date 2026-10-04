// -----------------------------------------------------------------------
// <copyright file="LinqExtensions.cs" company="Estrelio">
// Copyright (c) Estrelio. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Estrelio.LinqExtensions;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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

    /// <summary>
    /// Includes a related entity, or a filtered collection of them, in the query if a condition is met.
    /// </summary>
    /// <remarks>
    /// Returns <see cref="IQueryable{T}"/> rather than <see cref="Microsoft.EntityFrameworkCore.Query.IIncludableQueryable{TEntity,TProperty}"/>:
    /// when the condition is not met nothing was included, so there is no navigation for a
    /// <c>ThenInclude</c> to continue from. Chain further includes with <c>IncludeIf</c> or <c>Include</c>.
    /// </remarks>
    /// <param name="source">The source.</param>
    /// <param name="condition">The condition.</param>
    /// <param name="navigationPropertyPath">The navigation to include, which may filter a collection with
    /// <c>Where</c>.</param>
    /// <typeparam name="TEntity">The type of the source.</typeparam>
    /// <typeparam name="TProperty">The type of the navigation property.</typeparam>
    /// <returns>The query, with the navigation included when the condition is met.</returns>
    public static IQueryable<TEntity> IncludeIf<TEntity, TProperty>(
        this IQueryable<TEntity> source,
        bool condition,
        Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        where TEntity : class
    {
        return condition ? source.Include(navigationPropertyPath) : source;
    }
}
