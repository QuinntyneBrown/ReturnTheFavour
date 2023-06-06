// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ReturnTheFavour.Core.AggregatesModel.MeasurementAggregate.Commands;
using ReturnTheFavour.Core.AggregatesModel.MeasurementAggregate.Queries;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

namespace ReturnTheFavour.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/{version:apiVersion}/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
public class MeasurementController
{
    private readonly IMediator _mediator;

    private readonly ILogger<MeasurementController> _logger;

    public MeasurementController(IMediator mediator,ILogger<MeasurementController> logger){
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [SwaggerOperation(
        Summary = "Update Measurement",
        Description = @"Update Measurement"
    )]
    [HttpPut(Name = "updateMeasurement")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(UpdateMeasurementResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<UpdateMeasurementResponse>> Update([FromBody]UpdateMeasurementRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Create Measurement",
        Description = @"Create Measurement"
    )]
    [HttpPost(Name = "createMeasurement")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(CreateMeasurementResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<CreateMeasurementResponse>> Create([FromBody]CreateMeasurementRequest  request,CancellationToken cancellationToken)
    {
        return await _mediator.Send(request, cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get Measurements",
        Description = @"Get Measurements"
    )]
    [HttpGet(Name = "getMeasurements")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetMeasurementsResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetMeasurementsResponse>> Get(CancellationToken cancellationToken)
    {
        return await _mediator.Send(new GetMeasurementsRequest(), cancellationToken);
    }

    [SwaggerOperation(
        Summary = "Get Measurement by id",
        Description = @"Get Measurement by id"
    )]
    [HttpGet("{measurementId:guid}", Name = "getMeasurementById")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(GetMeasurementByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetMeasurementByIdResponse>> GetById([FromRoute]Guid measurementId,CancellationToken cancellationToken)
    {
        var request = new GetMeasurementByIdRequest(){MeasurementId = measurementId};

        var response = await _mediator.Send(request, cancellationToken);

        if (response.Measurement == null)
        {
            return new NotFoundObjectResult(request.MeasurementId);
        }

        return response;
    }

    [SwaggerOperation(
        Summary = "Delete Measurement",
        Description = @"Delete Measurement"
    )]
    [HttpDelete("{measurementId:guid}", Name = "deleteMeasurement")]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(DeleteMeasurementResponse), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<DeleteMeasurementResponse>> Delete([FromRoute]Guid measurementId,CancellationToken cancellationToken)
    {
        var request = new DeleteMeasurementRequest() {MeasurementId = measurementId };

        return await _mediator.Send(request, cancellationToken);
    }

}


