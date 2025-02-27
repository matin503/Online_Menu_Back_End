﻿using Microsoft.AspNetCore.Mvc.Filters;
using Online.Menu.InfraStructure.Framework.ApiResponses;

namespace Online.Menu.InfraStructure.InfraStracture.Framework.ApiRequests;

public class PaginationValidationAttribute(UInt16 maxPageNo = UInt16.MaxValue, UInt16 maxPageSize = UInt16.MaxValue) : ActionFilterAttribute
{
    private readonly UInt16 _maxPageNo = maxPageNo;
    private readonly UInt16 _maxPageSize = maxPageSize;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var pageNo = context.HttpContext.Request.Query.SingleOrDefault(x => x.Key.Equals("PageNo", StringComparison.CurrentCultureIgnoreCase));
        var pageSize = context.HttpContext.Request.Query.SingleOrDefault(x => x.Key.Equals("PageSize", StringComparison.CurrentCultureIgnoreCase));

        if (string.IsNullOrEmpty(pageNo.Value) || string.IsNullOrEmpty(pageSize.Value) || pageNo.Value == "0" || pageSize.Value == "0")
            context.Result = ApiResponseFactory.CreateBadRequest("Pagination is not valid");
        else if (UInt16.Parse(pageNo.Value) > _maxPageNo || UInt16.Parse(pageSize.Value) > _maxPageSize)
            context.Result = ApiResponseFactory.CreateBadRequest("Pagination is outside of the range");
    }
}
