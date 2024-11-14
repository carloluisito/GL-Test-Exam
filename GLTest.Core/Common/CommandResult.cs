namespace GLTest.Core.Common
{
    public class CommandResult<T> : ICommandResult<T>
    {
        public T Result { get; private set; }
        public bool IsSuccessful => Error == null && !Errors.Any();
        public ErrorModel? Error { get; private set; }
        public List<ErrorModel?> Errors { get; private set; }

        public CommandResult(T terms)
        {
            Result = terms;
            Errors = new List<ErrorModel?>();
        }

        public CommandResult(string errorCode, string errorMessage)
        {
            Error = new ErrorModel { Code = errorCode ?? "ErrorCode missing", Message = errorMessage ?? "Error message missing" };
        }

        public CommandResult(List<ErrorModel?> error)
        {
            Errors = new List<ErrorModel?>();
            Errors.AddRange(error);
        }

        public CommandResult(string code, string[] errors)
        {
            var collection = new List<ErrorModel?>();
            if (errors != null)
            {
                foreach (var item in errors)
                {
                    collection.Add(new ErrorModel { Code = code, Message = item });
                }
            }

            Errors = collection;
        }

        public CommandResult(string errorCode, string errorMessage, T result)
        {
            Error = new ErrorModel { Code = errorCode ?? "ErrorCode missing", Message = errorMessage ?? "Error message missing" };
            Result = result;
        }

        public CommandResult(ErrorModel errorCode)
        {
            Error = errorCode;
        }
    }
}
