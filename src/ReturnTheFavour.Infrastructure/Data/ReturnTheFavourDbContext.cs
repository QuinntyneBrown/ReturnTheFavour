// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ReturnTheFavour.Core;
using Microsoft.EntityFrameworkCore;
using ReturnTheFavour.Core.AggregatesModel.MeasurementAggregate;

namespace ReturnTheFavour.Infrastructure.Data;

public class ReturnTheFavourDbContext: DbContext,IReturnTheFavourDbContext
{
    public ReturnTheFavourDbContext(DbContextOptions<ReturnTheFavourDbContext> options)    : base(options)
    {
    }

    public DbSet<Measurement> Measurements { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ReturnTheFavour");

        base.OnModelCreating(modelBuilder);

    }

}


