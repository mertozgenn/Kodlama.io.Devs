using System;
using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguageCommand
{
	public class UpdateProgrammingLanguageValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
	{
		public UpdateProgrammingLanguageValidator()
		{
			RuleFor(x => x.Name).NotEmpty();
		}
	}
}

