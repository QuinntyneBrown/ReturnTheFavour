// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ReturnTheFavour.Core.AggregatesModel.MeasurementAggregate;

public static class MeasurementExtensions
{
    public static MeasurementDto ToDto(this Measurement measurement)
    {
        return new MeasurementDto
        {
            Weight = measurement.Weight,
            MeasurementId = measurement.MeasurementId,
        };

    }

    public async static Task<List<MeasurementDto>> ToDtosAsync(this IQueryable<Measurement> measurements,CancellationToken cancellationToken)
    {
        return await measurements.Select(x => x.ToDto()).ToListAsync(cancellationToken);
    }

}


