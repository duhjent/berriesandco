using System.ComponentModel.DataAnnotations;

namespace BerriesAndCoBackend.API;

// TODO: investigate why length is not validating
public record GetAnagramsRequest([Length(5, 5)] string Word);
