// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ReturnTheFavour.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ReturnTheFavourDbContext>
{
    public ReturnTheFavourDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ReturnTheFavourDbContext>();

        var basePath = Path.GetFullPath("../ReturnTheFavour.Api");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", false)
            .Build();

        var connectionString = configuration.GetConnectionString("DefualtConnection");

        builder.UseSqlServer(connectionString);

        return new ReturnTheFavourDbContext(builder.Options);
    }
}
