// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ReturnTheFavour.Core.AggregatesModel.MeasurementAggregate.Queries;

public class GetMeasurementByIdRequest: IRequest<GetMeasurementByIdResponse>
{
    public Guid MeasurementId { get; set; }
}


public class GetMeasurementByIdResponse
{
    public required MeasurementDto Measurement { get; set; }
}


public class GetMeasurementByIdRequestHandler: IRequestHandler<GetMeasurementByIdRequest,GetMeasurementByIdResponse>
{
    private readonly IReturnTheFavourDbContext _context;

    private readonly ILogger<GetMeasurementByIdRequestHandler> _logger;

    public GetMeasurementByIdRequestHandler(ILogger<GetMeasurementByIdRequestHandler> logger,IReturnTheFavourDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<GetMeasurementByIdResponse> Handle(GetMeasurementByIdRequest request,CancellationToken cancellationToken)
    {
        return new () {
            Measurement = (await _context.Measurements.AsNoTracking().SingleOrDefaultAsync(x => x.MeasurementId == request.MeasurementId)).ToDto()
        };

    }

}



