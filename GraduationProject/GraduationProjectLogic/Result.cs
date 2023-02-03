namespace GraduationProject.GraduationProjectLogic
{
    public class Result<T>
    {
        public T Value { get; set; }

        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }


        public static Result<T> Success(T value)
        {
            return new Result<T>
            {
                IsSuccess = true,
                Value = value,
                ErrorMessage = string.Empty
            };
        }
        public static Result<T> Failure(string error)
        {
            return new Result<T>
            {
                IsSuccess= false,
                ErrorMessage = error,
                Value=default(T)
            };
        }
    }
}
