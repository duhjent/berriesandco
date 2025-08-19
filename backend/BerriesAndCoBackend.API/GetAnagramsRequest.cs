using System.ComponentModel.DataAnnotations;

namespace BerriesAndCoBackend.API;

// TODO: investigate why length is not validating
public record GetAnagramsRequest([property: StringLength(5, MinimumLength = 5)] string Word);
