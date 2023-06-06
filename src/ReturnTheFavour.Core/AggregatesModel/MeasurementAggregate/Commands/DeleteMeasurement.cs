// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ReturnTheFavour.Core.AggregatesModel.MeasurementAggregate.Commands;

public class DeleteMeasurementRequestValidator: AbstractValidator<DeleteMeasurementRequest>
{
    public DeleteMeasurementRequestValidator(){

        RuleFor(x => x.MeasurementId).NotEqual(default(Guid));

    }

}


public class DeleteMeasurementRequest: IRequest<DeleteMeasurementResponse>
{
    public Guid MeasurementId { get; set; }
}


public class DeleteMeasurementResponse
{
    public required MeasurementDto Measurement { get; set; }
}


public class DeleteMeasurementRequestHandler: IRequestHandler<DeleteMeasurementRequest,DeleteMeasurementResponse>
{
    private readonly IReturnTheFavourDbContext _context;

    private readonly ILogger<DeleteMeasurementRequestHandler> _logger;

    public DeleteMeasurementRequestHandler(ILogger<DeleteMeasurementRequestHandler> logger,IReturnTheFavourDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<DeleteMeasurementResponse> Handle(DeleteMeasurementRequest request,CancellationToken cancellationToken)
    {
        var measurement = await _context.Measurements.FindAsync(request.MeasurementId);

        _context.Measurements.Remove(measurement);

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Measurement = measurement.ToDto()
        };
    }

}



