using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommand : IRequest<CreatedProgrammingTechnologyDto>
    {
        public string Name { get; set; }
        public string ProgrammingLanguageId { get; set; }
    }

    public class CreateProgrammingTechnologyCommandHandler : IRequestHandler<CreateProgrammingTechnologyCommand, CreatedProgrammingTechnologyDto>
    {
        private readonly IMapper _mapper;
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;

        public CreateProgrammingTechnologyCommandHandler(IMapper mapper, IProgrammingTechnologyRepository programmingTechnologyRepository)
        {
            _mapper = mapper;
            _programmingTechnologyRepository = programmingTechnologyRepository;
        }

        public async Task<CreatedProgrammingTechnologyDto> Handle(CreateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
        {
            ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);
            ProgrammingTechnology createdProgrammingTechnology = await _programmingTechnologyRepository.AddAsync(mappedProgrammingTechnology);
            CreatedProgrammingTechnologyDto createdProgrammingTechnologyDto = _mapper.Map<CreatedProgrammingTechnologyDto>(createdProgrammingTechnology);
            return createdProgrammingTechnologyDto;
        }
    }
}
