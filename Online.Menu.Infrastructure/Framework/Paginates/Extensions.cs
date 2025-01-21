﻿using Online.Menu.InfraStructure.Framework.AppModels;

namespace Online.Menu.InfraStructure.Paginates;

public static class Extensions
{
    public static IQueryable<T> Paginate<T>(this PaginationModel pagination, IQueryable<T> query)
    {
        return query.Skip((pagination.PageIndex - 1) * pagination.PageSize).Take(pagination.PageSize);
    }

    public static IQueryable<T> Paginate<T>(this IQueryable<T> query, PaginationModel pagination)
    {
        return query.Skip(pagination.PageIndex * pagination.PageSize).Take(pagination.PageSize);
    }
}
