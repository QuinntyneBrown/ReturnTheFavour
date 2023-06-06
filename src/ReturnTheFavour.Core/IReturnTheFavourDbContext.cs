// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ReturnTheFavour.Core.AggregatesModel.MeasurementAggregate;

namespace ReturnTheFavour.Core;

public interface IReturnTheFavourDbContext
{
    DbSet<Measurement> Measurements { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}


