﻿using Microsoft.AspNetCore.Mvc;
using Scout.Api.Api.Controllers.Middleware;

namespace Scout.Api.Controllers.Middleware
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthAttribute : TypeFilterAttribute
    {
        public BasicAuthAttribute(string realm = @"My Realm") : base(typeof(BasicAuthFilter))
        {
            Arguments = new object[] { realm };
        }
    }
}