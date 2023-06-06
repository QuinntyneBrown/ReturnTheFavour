// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ReturnTheFavour.Core.AggregatesModel.MeasurementAggregate.Commands;

public class CreateMeasurementRequestValidator: AbstractValidator<CreateMeasurementRequest>
{
    public CreateMeasurementRequestValidator(){

        RuleFor(x => x.Weight).NotNull();

    }

}


public class CreateMeasurementRequest: IRequest<CreateMeasurementResponse>
{
    public int Weight { get; set; }
}


public class CreateMeasurementResponse
{
    public required MeasurementDto Measurement { get; set; }
}


public class CreateMeasurementRequestHandler: IRequestHandler<CreateMeasurementRequest,CreateMeasurementResponse>
{
    private readonly IReturnTheFavourDbContext _context;

    private readonly ILogger<CreateMeasurementRequestHandler> _logger;

    public CreateMeasurementRequestHandler(ILogger<CreateMeasurementRequestHandler> logger,IReturnTheFavourDbContext context){
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<CreateMeasurementResponse> Handle(CreateMeasurementRequest request,CancellationToken cancellationToken)
    {
        var measurement = new Measurement();

        _context.Measurements.Add(measurement);

        measurement.Weight = request.Weight;

        await _context.SaveChangesAsync(cancellationToken);

        return new ()
        {
            Measurement = measurement.ToDto()
        };

    }

}



