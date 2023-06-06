// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ReturnTheFavour.Core;
using ReturnTheFavour.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {

        services.AddScoped<IReturnTheFavourDbContext, ReturnTheFavourDbContext>();
        services.AddDbContextPool<ReturnTheFavourDbContext>(options =>
        {
            options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("ReturnTheFavour.Infrastructure"))
            .EnableThreadSafetyChecks(false);
        });
    }
}
