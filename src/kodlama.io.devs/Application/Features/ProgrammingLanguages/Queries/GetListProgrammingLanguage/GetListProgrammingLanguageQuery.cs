using System;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
	public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
	{
		public PageRequest PageRequest { get; set; }
	}

    public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
    {
        private readonly IProgrammingLanguageRepository _programmingLangugageRepository;
        private readonly IMapper _mapper;

        public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLangugageRepository, IMapper mapper)
        {
            _programmingLangugageRepository = programmingLangugageRepository;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLangugageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            ProgrammingLanguageListModel mappedProgrammingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(programmingLanguages);
            return mappedProgrammingLanguageListModel;
        }
    }
}

