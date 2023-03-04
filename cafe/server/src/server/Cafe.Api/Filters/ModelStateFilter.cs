﻿using Cafe.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Cafe.Api.Filters
{
    public class ModelStateFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context
                    .ModelState
                    .Values
                    .SelectMany(v => v.Errors.Select(e => e.ErrorMessage));

                context.Result = new BadRequestObjectResult(Error.Validation(errors));
            }
        }
    }
}
