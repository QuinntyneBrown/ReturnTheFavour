// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ReturnTheFavour.Core.AggregatesModel.MeasurementAggregate.Commands;

public class UpdateMeasurementRequestValidator: AbstractValidator<UpdateMeasurementRequest>
{
    public UpdateMeasurementRequestValidator(){

        RuleFor(x => x.Weight).NotNull();
        RuleFor(x => x.MeasurementId).NotEqual(default(Guid));

    }

}


public class UpdateMeasurementRequest: IRequest<UpdateMeasurementResponse>
{
    public int Weight { get; set; }
    public Guid MeasurementId { get; set; }
}


public class UpdateMeasurementResponse
{
    public required MeasurementDto Measurement { get; set; }
}


public class UpdateMeasurementRequestHandler: IRequestHandler<UpdateMeasurementRequest,UpdateMeasurementResponse>
{
    private readonly IReturnTheFavourDbContext _context;

    private readonly ILogger<UpdateMeasurementRequestHandler> _logger;

    public UpdateMeasurementRequestHandler(ILogger<UpdateMeasurementRequestHandler> logger,IReturnTheFavourDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<UpdateMeasurementResponse> Handle(UpdateMeasurementRequest request,CancellationToken cancellationToken)
    {
        var measurement = await _context.Measurements.SingleAsync(x => x.MeasurementId == request.MeasurementId);

        measurement.Weight = request.Weight;
        measurement.MeasurementId = request.MeasurementId;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Measurement = measurement.ToDto()
        };

    }

}



