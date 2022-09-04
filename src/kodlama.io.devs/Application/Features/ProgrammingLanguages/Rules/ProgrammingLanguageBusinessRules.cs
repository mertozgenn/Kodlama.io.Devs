using System;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Rules
{
	public class ProgrammingLanguageBusinessRules
	{
		private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming language name exists.");
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenUpdated(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming language name exists.");
        }

        public async Task ProgrammingLangugageShouldExistWhenRequestedAsync(int id)
        {
            ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == id, enableTracking: false);
            if (programmingLanguage == null) throw new BusinessException("Requested programming language does not exist.");
        }
    }
}

