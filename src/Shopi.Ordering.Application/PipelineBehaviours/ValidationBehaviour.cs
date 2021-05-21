
using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = Shopi.Ordering.Application.Exceptions.ValidationException;

namespace Shopi.Ordering.Application.PipelineBehaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        private readonly IValidator<TRequest> _validators;

        public ValidationBehaviour(IValidator<TRequest> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators.Validate(request).Errors
                                      .Where(x => x != null)
                                      .Select(x => x.ToString())
                                      .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
