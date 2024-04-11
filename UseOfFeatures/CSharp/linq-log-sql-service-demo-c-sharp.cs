public static IQueryable<T> LogSql<T>(this IQueryable<T> query, ILogger logger ,userName, string description="")
        {
            logger?.LogInformation($"Description: {description}, Query: {query.ToQueryString()}");
            return query;
        }


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Utilities.Extensions;


namespace Api.Managers

public class ExampleManager : BaseManager
	{
		private readonly ILogger<ExampleManager> _logger;

	}
public ExampleManager(
		ILogger<ExampleManager> logger,
        {
		_logger = logger;
        }

	public List<Object> exampleList(User usr)
	{
		return dbContext.exampleTable.Where(x=>x.Type == TypeEnum.typeOne).LogSql(_logger,usr.Name,"Example-Table-Type-1-ToList").ToList();
	
	}