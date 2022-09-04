using System;
using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
	public interface IProgrammingLanguageRepository : IRepository<ProgrammingLanguage>, IAsyncRepository<ProgrammingLanguage>
	{
	}
}

