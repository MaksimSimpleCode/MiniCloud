using Application.Interfaces;
using Domain;
using MiniCloud.Helpers;

namespace MiniCloud.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        //private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IConfiguration configuration/*, IMapper mapper*/)
        {
            _userRepository = userRepository;
            _configuration = configuration;
           // _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository
                .GetAll()
                .FirstOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            if (user == null)
            {
                // todo: need to add logger
                return null;
            }

            var token = _configuration.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        //TODO поменять USER на View модел. Добавить AutoMapper или Mapster
        public async Task<AuthenticateResponse> Register(User userModel)
        {
            //var user = _mapper.Map<User>(userModel);
            var user = new User();

            var addedUser = await _userRepository.Add(user);

            var response = Authenticate(new AuthenticateRequest
            {
                Username = user.UserName,
                Password = user.Password
            });

            return response;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(Guid id)
        {
            return _userRepository.GetById(id);
        }
    }
}
