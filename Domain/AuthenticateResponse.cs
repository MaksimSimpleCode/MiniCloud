namespace Domain
{
    public class AuthenticateResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }

        public AuthenticateResponse(string message)
        {
            Message = message;
        }
        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            Token = token;
        }
    }
}
