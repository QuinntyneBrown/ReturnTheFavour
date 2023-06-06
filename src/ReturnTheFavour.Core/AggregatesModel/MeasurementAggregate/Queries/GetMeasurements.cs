// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ReturnTheFavour.Core.AggregatesModel.MeasurementAggregate.Queries;

public class GetMeasurementsRequest: IRequest<GetMeasurementsResponse> { }

public class GetMeasurementsResponse
{
    public required List<MeasurementDto> Measurements { get; set; }
}


public class GetMeasurementsRequestHandler: IRequestHandler<GetMeasurementsRequest,GetMeasurementsResponse>
{
    private readonly IReturnTheFavourDbContext _context;

    private readonly ILogger<GetMeasurementsRequestHandler> _logger;

    public GetMeasurementsRequestHandler(ILogger<GetMeasurementsRequestHandler> logger,IReturnTheFavourDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetMeasurementsResponse> Handle(GetMeasurementsRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Measurements = await _context.Measurements.AsNoTracking().ToDtosAsync(cancellationToken)
        };

    }

}



