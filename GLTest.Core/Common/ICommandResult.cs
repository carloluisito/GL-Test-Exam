namespace GLTest.Core.Common
{
    public interface ICommandResult<T> : IExecuteResult
    {
        T Result { get; }
    }

    public interface IExecuteResult
    {
        bool IsSuccessful { get; }
        ErrorModel? Error { get; }
    }
}
