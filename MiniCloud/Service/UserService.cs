using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using MiniCloud.Helpers;
using MiniCloud.Models;
using System.Text.Json;

namespace MiniCloud.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> userRepository, IConfiguration configuration, IMapper mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapper = mapper;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _userRepository
                .GetAll()
                .FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user == null)
            {
                // todo: need to add logger
                return null;
            }

            var token = _configuration.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        //TODO Реализовать проверку UserExist по Email. Сделать возвращаемым значением интерфейс IAuthenticateResponse
        public async Task<AuthenticateResponse> Register(UserModel userModel)
        {
            var userExist=_userRepository.GetAll().FirstOrDefault(u=>u.Email == userModel.Email);
            if(userExist != null) {
                return new AuthenticateResponse("User alrady exist!");
            }

            var user = _mapper.Map<User>(userModel);
            var registerData = DateTime.UtcNow;
            user.CreatedOn = registerData;
            user.ModefiedOn = registerData;

            var addedUser = await _userRepository.Add(user);

            var response = Authenticate(new AuthenticateRequest
            {
                //Username = user.UserName,
                Email = user.Email,
                Password = user.Password
            });
            response.Message = "Sucess!";
            return   response;
        }


        //public async Task<string> Auth(Guid id)
        //{
        //    var user = _userRepository.GetById(id);
        //    if (user!= null)
        //    {
        //        var response = new
        //        {
        //            id = user.Id,
        //            email = user.Email,
        //            diskSpace = user.DiskSpace,
        //            usedSpace = user.UsedSpace,
        //            avatar = user.Avatar

        //        };

        //        string json = JsonSerializer.Serialize(response);
        //        return  json;
        //    }

        //    return JsonSerializer.Serialize(new {message = "User not found"});
        //}

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
