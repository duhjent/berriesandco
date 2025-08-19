using System.ComponentModel.DataAnnotations;

namespace BerriesAndCoBackend.API;

public static class MinimalApiExtensions
{
    public static RouteHandlerBuilder Validate<T>(this RouteHandlerBuilder builder)
    {
        builder.AddEndpointFilter(async (invocationContext, next) =>
        {
            var argument = invocationContext.Arguments.OfType<T>().FirstOrDefault();

            var results = new List<ValidationResult>();
            var context = new ValidationContext(argument!);

            var isValid = Validator.TryValidateObject(argument!, context, results, true);

            if (isValid)
            {
                return await next(invocationContext);
            }

            var errorMessage =
                string.Join("|", results.Select(x => x.ErrorMessage));

            return Results.Problem(errorMessage, statusCode: 400);
        });

        return builder;
    }
}