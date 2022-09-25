using System;
using Domain.Entities;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguageCommand
{
	public class CreateProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
	{
		public CreateProgrammingLanguageCommandValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
		}
	}
}

