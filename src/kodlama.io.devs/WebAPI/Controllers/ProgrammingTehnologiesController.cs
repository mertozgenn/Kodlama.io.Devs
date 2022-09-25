using Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.ProgrammingTechnologies.Queries.GetListProgrammingTechnologies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTehnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingTechnologyCommand createProgrammingTechnologyCommand)
        {
            CreatedProgrammingTechnologyDto createdProgrammingTechnologyDto = await Mediator.Send(createProgrammingTechnologyCommand);
            return Created("", createdProgrammingTechnologyDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetListProgrammingTechnologyQuery getListProgrammingTechnologyQuery)
        {
            ProgrammingTechnologyListModel result = await Mediator.Send(getListProgrammingTechnologyQuery);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteProgrammingTechnologyCommand deleteProgrammingTechnologyCommand)
        {
            DeletedProgrammingTechnologyDto result = await Mediator.Send(deleteProgrammingTechnologyCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateProgrammingTechnologyCommand updateProgrammingTechnologyCommand)
        {
            UpdatedProgrammingTechnologyDto result = await Mediator.Send(updateProgrammingTechnologyCommand);
            return Ok(result);
        }
    }
}
