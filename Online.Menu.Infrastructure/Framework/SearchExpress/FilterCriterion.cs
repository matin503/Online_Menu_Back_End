﻿using System.Linq.Expressions;

namespace Online.Menu.InfraStructure.Framework.SearchExpress;

public class FilterCriterion<T>
{
    public Expression<Func<T, object>> PropertyExpression { get; set; }
    public FilterOperation Operation { get; set; }
    public object? Value { get; set; }
    public LogicalOperation LogicalOperation { get; set; } = LogicalOperation.And;
    public OrderDirection? OrderDirection { get; set; }
}
