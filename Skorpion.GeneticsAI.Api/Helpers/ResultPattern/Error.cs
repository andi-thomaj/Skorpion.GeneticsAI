﻿namespace Skorpion.GeneticsAI.Api.Helpers.ResultPattern
{
    public record Error
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

        public static readonly Error NullValue = new(
            "General.Null",
            "Null value was provided",
            ErrorType.Failure);

        private Error(string code, string description, ErrorType type, List<string>? validationErrors = null)
        {
            Code = code;
            Description = description;
            Type = type;
            ValidationErrors = validationErrors ?? [];
        }

        public string Code { get; }

        public string Description { get; }

        public List<string> ValidationErrors { get; }

        public ErrorType Type { get; }

        public static Error Failure(string code, string description)
        {
            return new Error(code, description, ErrorType.Failure);
        }

        public static Error NotFound(string code, string description)
        {
            return new Error(code, description, ErrorType.NotFound);
        }

        public static Error Problem(string code, string description)
        {
            return new Error(code, description, ErrorType.Problem);
        }

        public static Error Conflict(string code, string description)
        {
            return new Error(code, description, ErrorType.Conflict);
        }

        public static Error Unauthorized(string code, string description)
        {
            return new Error(code, description, ErrorType.Unauthorized);
        }
    }
}
